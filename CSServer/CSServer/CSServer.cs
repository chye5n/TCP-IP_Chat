using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSServer
{
    public partial class CSServer : Form
    {
        public static CSServer ServerForm;

        public CSServer()
        {
            InitializeComponent();
            ServerForm = this;
            Txt_Ip.Text = IPAddressSetting.GetIp();                     //로컬 IP 입력, AddressList[1] = xxx.xxx.xxx.xxx
            Txt_Port.Text = "4000";                                     //Server 실행 포트
            CheckForIllegalCrossThreadCalls = false;                    //UI 컨트롤 업데이트에 대한 크로스 스레드 작업 오류 무시
        }

        private void Btn_Connect_Click(object sender, EventArgs e)  //Connect,버튼을 누른 경우
        {
            TcpThread.StartServer(Txt_Ip.Text, Txt_Port.Text);                                          //스레드 시작, TCP Listener 생성
            Btn_Connect.Enabled = false;                            //서버가 시작이 될 경우 Connect버튼 비활성화
            List_Receive.Items.Add("서버가 시작되었습니다.\n");     //서버 시작 메시지 표시
        }

        private void Btn_IntSend_Click(object sender, EventArgs e)     //int Send버튼을 누른 경우
        {
            TcpThread.IntDataSend(Convert.ToInt32(Txt_Int.Text));     //TextBox의 데이터 값 C# Client로 전송
            Txt_Int.Text = string.Empty;          //데이터 전송 후 txt의 텍스트 초기화
        }

        private void Btn_DoubleSend_Click(object sender, EventArgs e)  //double Send버튼을 누른 경우
        {
            TcpThread.DoubleDataSend(Convert.ToDouble(Txt_Double.Text));  //TextBox의 데이터 값 Client로 전송
            Txt_Double.Text = string.Empty;       //데이터 전송 후 txt의 텍스트 초기화
        }

        private void Btn_StringSend_Click(object sender, EventArgs e)  //string Send버튼을 누른 경우
        {
            TcpThread.StringDataSend(Txt_String.Text);  //TextBox의 데이터 값 Client로 전송
            Txt_String.Text = string.Empty;       //데이터 전송 후 txt의 텍스트 초기화
        }

        private void Btn_StructSend_Click(object sender, EventArgs e)  //Struct Send버튼을 누른 경우
        {
            TcpThread.SturctDataSend(Convert.ToInt32(Txt_Int.Text), Convert.ToDouble(Txt_Double.Text), Txt_String.Text);
            Txt_Int.Text = string.Empty;          //데이터 전송 후 txt의 텍스트 초기화
            Txt_Double.Text = string.Empty;
            Txt_String.Text = string.Empty;
        }

        private void Txt_Int_KeyPress(object sender, KeyPressEventArgs e)      //int textbox에 입력할 경우
        {   //숫자만 입력가능
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void Txt_Double_KeyPress(object sender, KeyPressEventArgs e)   //double textbox에 입력할 경우
        {   //숫자와 '.' 한개만 입력가능
            if (Txt_Double.Text.Contains('.')) { if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; } }
            else { if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != 8) { e.Handled = true; } }
        }

        private void Txt_String_KeyPress(object sender, KeyPressEventArgs e)   //string textbox에 입력할 경우
        {   //문자만 입력 가능
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; }
        }
    }
}
