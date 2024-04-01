using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace CSServer
{
    internal class TcpThread
    {
        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STSend    //구조체 선언
        {
            public int TxtInt;

            public double TxtDouble;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]    //길이가 20인 string
            public string TxtString;

            public STSend(int TxtInt, double TxtDouble, string TxtString)
            {
                this.TxtInt = Convert.ToInt32(TxtInt);
                this.TxtDouble = Convert.ToDouble(TxtDouble);
                this.TxtString = TxtString;
            }
        };

        static private TcpListener tcpServer;     //TCP Server를 나타내는 TcpListener 객체 생성
        static Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();   //연결되어있는 Client들의 Dictionary

        static public void StartServer(string ip, string port)
        {
            //TCP Listener 생성 및 Txt_Port에 입력한 번호의 포트에서 대기
            tcpServer = new TcpListener(IPAddress.Parse(ip), Convert.ToInt32(port));
            tcpServer.Start();

            //Accept 스레드 시작
            Thread acceptThread = new Thread(new ThreadStart(AcceptThread));    //클라이언트 연결 수락 및 연결된 클라이언트를 처리하는 스레드 시작
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        static private void AcceptThread()
        {
            while (true)
            {
                // 클라이언트 연결 수락
                TcpClient client = tcpServer.AcceptTcpClient();
                string clientIdentifier = $"{((IPEndPoint)client.Client.RemoteEndPoint).Address}:{((IPEndPoint)client.Client.RemoteEndPoint).Port}";

                // 클라이언트 식별자와 TcpClient 추가
                connectedClients.Add(clientIdentifier, client);

                // 연결된 클라이언트를 처리하는 스레드 시작
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientThread));
                clientThread.IsBackground = true;
                clientThread.Start(clientIdentifier);
            }
        }

        static private void HandleClientThread(object clientIdentifierObj)
        {
            string clientIdentifier = (string)clientIdentifierObj;
            TcpClient client = connectedClients[clientIdentifier];

            //Client 연결 시 메시지 표시
            CSServer.ServerForm.List_Receive.Items.Add($"Client({clientIdentifier})가 접속하였습니다.\n");

            // 클라이언트와 통신하는 코드 작성
            NetworkStream nsStream = client.GetStream();

            int length;
            byte[] bytes = new byte[75];

            while (true)
            {
                try
                {
                    Array.Clear(bytes, 0x0, bytes.Length);
                    length = nsStream.Read(bytes, 0, bytes.Length);
                }
                catch { CSServer.ServerForm.List_Receive.Items.Add($"Client({clientIdentifierObj})가 종료하였습니다.\n"); break; }    //Client가 연결을 종료할 경우 메시지 표시
                if (length != 0)
                {
                    if (Encoding.Default.GetString(bytes, 0, 1) == "1")
                    {
                        ReceiveStruct(bytes, clientIdentifier);
                        SendDataToClients(bytes, length, clientIdentifier);
                    }
                    else if (Encoding.Default.GetString(bytes, 0, 1) == "3")
                    {
                        ReceiveIntData(bytes, clientIdentifier);
                        SendDataToClients(bytes, length, clientIdentifier);
                    }
                    else if (Encoding.Default.GetString(bytes, 0, 1) == "5")
                    {
                        ReceiveDoubleData(bytes, clientIdentifier);
                        SendDataToClients(bytes, length, clientIdentifier);
                    }
                    else if (Encoding.Default.GetString(bytes, 0, 1) == "7")
                    {
                        ReceiveStringData(bytes, length, clientIdentifier);
                        SendDataToClients(bytes, length, clientIdentifier);
                    }
                }
            }
            // 클라이언트가 연결을 종료하면 Dictionary에서 해당 클라이언트 제거
            connectedClients.Remove(clientIdentifier);
        }

        static private void SendDataToClients(byte[] data, int length, string clientIdentifier = "")
        {
            foreach (var client in connectedClients)
            {
                if (client.Key != clientIdentifier)
                {
                    NetworkStream stream = client.Value.GetStream();
                    stream.Write(data, 0, length);
                }
            }
        }

        static private void ReceiveIntData(byte[] bytes, string clientIdentifier)
        {
            int idata = BitConverter.ToInt32(bytes, 1); //받은 byte를 문자열로 변환하고 
            CSServer.ServerForm.List_Receive.Items.Add($"Client( {clientIdentifier} ) : {idata}\n");
        }

        static private void ReceiveDoubleData(byte[] bytes, string clientIdentifier)
        {
            double ddata = BitConverter.ToDouble(bytes, 1); //받은 byte를 문자열로 변환하고 
            CSServer.ServerForm.List_Receive.Items.Add($"Client( {clientIdentifier} ) : {ddata:0.00}\n");
        }

        static private void ReceiveStringData(byte[] bytes, int length, string clientIdentifier)
        {
            string sdata = Encoding.Default.GetString(bytes, 1, length - 1); //받은 byte를 문자열로 변환하고 표시
            sdata = sdata.Replace("\0", "");
            CSServer.ServerForm.List_Receive.Items.Add($"Client({clientIdentifier}) : {sdata}\n");
        }

        static private void ReceiveStruct(byte[] bytes, string clientIdentifier)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(STSend)));
            Marshal.Copy(bytes, 1, ptr, Marshal.SizeOf(typeof(STSend)));
            STSend receiveData = Marshal.PtrToStructure<STSend>(ptr);
            Marshal.FreeHGlobal(ptr);
            CSServer.ServerForm.List_Receive.Items.Add($"Client({clientIdentifier}) : int({receiveData.TxtInt}), double({receiveData.TxtDouble:0.00}), string({receiveData.TxtString})\n");
        }

        static public void IntDataSend(int idata)                    //TextBox의 값을 Client에 전송하는 함수
        {
            string strFormatted = "2";
            byte[] bFormatted = Encoding.Default.GetBytes(strFormatted);
            byte[] buffer = BitConverter.GetBytes(idata);   //문자열을 byte로 변환하여 Client에 전송
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bFormatted[0]);
            buffer = bytes.ToArray();

            SendDataToClients(buffer, buffer.Length);
            CSServer.ServerForm.List_Receive.Items.Add($"송신 : {idata}\n");      //전송된 데이터를 나타내는 메시지 표시
        }

        static public void DoubleDataSend(double ddata)                    //TextBox의 값을 Client에 전송하는 함수
        {
            string strFormatted = "4";
            byte[] bFormatted = Encoding.Default.GetBytes(strFormatted);
            byte[] buffer = BitConverter.GetBytes(ddata);   //문자열을 byte로 변환하여 Client에 전송
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bFormatted[0]);
            buffer = bytes.ToArray();

            SendDataToClients(buffer, buffer.Length);
            CSServer.ServerForm.List_Receive.Items.Add($"송신 : {ddata:0.00}\n");      //전송된 데이터를 나타내는 메시지 표시
        }

        static public void StringDataSend(string sdata)
        {
            string strdata = "6" + sdata;
            byte[] bFormatted = Encoding.Default.GetBytes(strdata);
            SendDataToClients(bFormatted, bFormatted.Length);
            CSServer.ServerForm.List_Receive.Items.Add($"송신 : {sdata}\n");
        }

        static public void SturctDataSend(int txt_int, double txt_double, string txt_string)
        {
            STSend send = new STSend(txt_int, txt_double, txt_string);
            // 구조체를 바이트 배열로 변환하여 전송
            byte[] buffer = new byte[Marshal.SizeOf(send)];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(send, handle.AddrOfPinnedObject(), false);
            handle.Free();

            string strFormatted = "0";
            byte[] bFormatted = Encoding.Default.GetBytes(strFormatted);
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bFormatted[0]);
            buffer = bytes.ToArray();
            CSServer.ServerForm.List_Receive.Items.Add($"송신 : int({send.TxtInt}), double({send.TxtDouble:0.00}), string({send.TxtString})\n"); //전송된 데이터를 나타내는 메시지 표시
            SendDataToClients(buffer, buffer.Length);
        }
    }
}
