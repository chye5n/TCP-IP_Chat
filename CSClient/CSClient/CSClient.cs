using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSClient
{
    public partial class CSClient : Form
    {
        public static CSClient ClientForm;

        public CSClient()
        {
            InitializeComponent();
            ClientForm = this;
            Txt_ServerIp.Text = IPAddressSetting.GetIp();            //로컬 IP 입력, AddressList[1] = xxx.xxx.xxx.xxx
            Txt_ClientIp.Text = IPAddressSetting.GetIp();
            Txt_ServerPort.Text = "4000";                               //Server 접속 포트
            Txt_ClientPort.Text = "5000";                               //임의로 정한 기본 포트
            CheckForIllegalCrossThreadCalls = false;                    //UI 컨트롤 업데이트에 대한 크로스 스레드 작업 오류 무시
        }

        private void Btn_Connect_Click(object sender, EventArgs e)     //Connect 버튼을 눌렀을 경우
        {
            ClientThread.ServerConnect(Txt_ServerIp.Text, Txt_ServerPort.Text, Txt_ClientIp.Text, Txt_ClientPort.Text);
        }

        private void Btn_IntSend_Click(object sender, EventArgs e)     //int Send 버튼을 눌렀을 경우
        {
            ClientThread.IntDataSend(Convert.ToInt32(Txt_Int.Text));     //TextBox의 데이터 값 Server로 전송
            Txt_Int.Text = string.Empty;
        }

        private void Btn_DoubleSend_Click(object sender, EventArgs e)  //double Send 버튼을 눌렀을 경우
        {
            ClientThread.DoubleDataSend(Convert.ToDouble(Txt_Double.Text));  //TextBox의 데이터 값 Server로 전송
            Txt_Double.Text = string.Empty;
        }

        private void Btn_StringSend_Click(object sender, EventArgs e)  //string Send 버튼을 눌렀을 경우
        {
            ClientThread.StringDataSend(Txt_String.Text);  //TextBox의 데이터 값 Server로 전송
            Txt_String.Text = string.Empty;
        }

        private void Btn_StructSend_Click(object sender, EventArgs e)  //Struct Send버튼을 누른 경우
        {
            ClientThread.SendSturctData(Convert.ToInt32(Txt_Int.Text), Convert.ToDouble(Txt_Double.Text), Txt_String.Text);
            Txt_Int.Text = string.Empty;
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
