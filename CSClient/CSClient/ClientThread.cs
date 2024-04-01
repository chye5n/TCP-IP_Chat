using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CSClient
{
    internal class ClientThread
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

        static private NetworkStream nsStream;    //데이터 통신을 위한 NetworkStream 객체 생성

        static public void ServerConnect(string ServerIp, string ServerPort, string ClientIp, string ClientPort)
        {
            //Server에 연결 시도
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ClientIp), Convert.ToInt32(ClientPort));
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(ServerIp), Convert.ToInt32(ServerPort));
            }
            catch   //Server에 연결을 할 수 없을 경우 예외처리
            {
                DialogResult result = MessageBox.Show("서버와 접속할 수 없습니다.\n다시 시도하겠습니까?", "접속 오류", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) { Application.Restart(); return; }
                else { Application.Exit(); }
            }
            nsStream = tcpClient.GetStream();       //Server와 연결 성공하면 데이터를 주고 받을 수 있는 NetworkStream을 가져옴
                                                    //데이터 수신 스레드 시작
            Thread receiveThread = new Thread(new ThreadStart(ReceiveThread_Run));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        static private void ReceiveThread_Run()
        {
            CSClient.ClientForm.List_Receive.Items.Add("서버 접속 완료\n");    //Server와의 연결 성공 할 경우 메시지 표시

            int length = 0; //Server로부터 받아온 데이터의 길이 저장
            byte[] bytes = new byte[75];   //Server로부터 받아온 데이터 값 저장

            while (true)
            {
                try
                {
                    Array.Clear(bytes, 0x0, bytes.Length);
                    length = nsStream.Read(bytes, 0, bytes.Length);    //데이터를 읽어 온다.
                }
                catch  //Server와 연결이 끊겼을 경우 예외처리
                {
                    MessageBox.Show("서버와 접속이 끊겼습니다.");
                    Application.Exit();
                }

                if (Encoding.Default.GetString(bytes, 0, 1) == "0")
                {
                    ReceiveStruct(bytes, "C# Server"); 
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "1")
                {
                    ReceiveStruct(bytes, "C++ Client"); 
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "2")
                {
                    ReceiveIntData(bytes, "C# Server");
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "3")
                {
                    ReceiveIntData(bytes, "C++ Client");
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "4")
                {
                    ReceiveDoubleData(bytes, "C# Server");
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "5")
                {
                    ReceiveDoubleData(bytes, "C++ Client");
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "6")
                {
                    ReceiveStringData(bytes, length, "C# Server");
                }
                else if (Encoding.Default.GetString(bytes, 0, 1) == "7")
                {
                    ReceiveStringData(bytes, length, "C++ Client");
                }
            }
        }

        static private void ReceiveIntData(byte[] bytes, string language)
        {
            int idata = BitConverter.ToInt32(bytes, 1); //받은 byte를 문자열로 변환하고 
            CSClient.ClientForm.List_Receive.Items.Add($"{language} : {idata}\n");
        }

        static private void ReceiveDoubleData(byte[] bytes, string language)
        {
            double ddata = BitConverter.ToDouble(bytes, 1); //받은 byte를 문자열로 변환하고 
            CSClient.ClientForm.List_Receive.Items.Add($"{language} : {ddata:0.00}\n");
        }

        static private void ReceiveStringData(byte[] bytes, int length, string language)
        {
            string sdata = Encoding.Default.GetString(bytes, 1, length - 1); //받은 byte를 문자열로 변환하고 표시
            sdata = sdata.Replace("\0", "");
            CSClient.ClientForm.List_Receive.Items.Add($"{language} : {sdata}\n");
        }

        static private void ReceiveStruct(byte[] bytes, string language)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(STSend)));
            Marshal.Copy(bytes, 1, ptr, Marshal.SizeOf(typeof(STSend)));
            STSend receiveData = Marshal.PtrToStructure<STSend>(ptr);
            Marshal.FreeHGlobal(ptr);
            CSClient.ClientForm.List_Receive.Items.Add($"{language} : int({receiveData.TxtInt}), double({receiveData.TxtDouble:0.00}), string({receiveData.TxtString})\n");
        }

        static public void IntDataSend(int idata)                  //TextBox의 값을 Server에 전송하는 함수
        {
            string strFormatted = "3";
            byte[] bFormatted = Encoding.Default.GetBytes(strFormatted);
            byte[] buffer = BitConverter.GetBytes(idata);   //문자열을 byte로 변환하여 Client에 전송
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bFormatted[0]);
            buffer = bytes.ToArray();
            nsStream.Write(buffer, 0, buffer.Length);

            CSClient.ClientForm.List_Receive.Items.Add($"송신 : {idata}\n");   //전송된 데이터를 나타내는 메시지 표시
        }

        static public void DoubleDataSend(double ddata)                  //TextBox의 값을 Server에 전송하는 함수
        {
            string strFormatted = "5";
            byte[] bFormatted = Encoding.Default.GetBytes(strFormatted);
            byte[] buffer = BitConverter.GetBytes(ddata);   //문자열을 byte로 변환하여 Client에 전송
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bFormatted[0]);
            buffer = bytes.ToArray();
            nsStream.Write(buffer, 0, buffer.Length);

            CSClient.ClientForm.List_Receive.Items.Add($"송신 : {ddata:0.00}\n");   //전송된 데이터를 나타내는 메시지 표시
        }

        static public void StringDataSend(string sdata)                  //TextBox의 값을 Server에 전송하는 함수
        {
            string data = "7" + sdata;                         //txt의 텍스트 값 저장
            byte[] msg = Encoding.Default.GetBytes(data);   //문자열을 byte로 변환하여 Client에 전송
            nsStream.Write(msg, 0, msg.Length);

            CSClient.ClientForm.List_Receive.Items.Add($"송신 : {sdata}\n");   //전송된 데이터를 나타내는 메시지 표시
        }

        static public void SendSturctData(int txt_int, double txt_double, string txt_string)
        {
            STSend sendData = new STSend(txt_int, txt_double, txt_string);
            // 구조체를 바이트 배열로 변환하여 전송
            byte[] buffer = new byte[Marshal.SizeOf(sendData)];
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(sendData, handle.AddrOfPinnedObject(), false);
            handle.Free();

            string strclassify = "1";
            byte[] bclassify = Encoding.Default.GetBytes(strclassify);
            List<byte> bytes = new List<byte>(buffer);
            bytes.Insert(0, bclassify[0]);
            buffer = bytes.ToArray();
            CSClient.ClientForm.List_Receive.Items.Add($"송신 : int({sendData.TxtInt}), double({sendData.TxtDouble:0.00}), string({sendData.TxtString})\n");   //전송된 데이터를 나타내는 메시지 표시
            nsStream.Write(buffer, 0, buffer.Length);
        }
    }
}
