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
            Txt_ServerIp.Text = IPAddressSetting.GetIp();            //���� IP �Է�, AddressList[1] = xxx.xxx.xxx.xxx
            Txt_ClientIp.Text = IPAddressSetting.GetIp();
            Txt_ServerPort.Text = "4000";                               //Server ���� ��Ʈ
            Txt_ClientPort.Text = "5000";                               //���Ƿ� ���� �⺻ ��Ʈ
            CheckForIllegalCrossThreadCalls = false;                    //UI ��Ʈ�� ������Ʈ�� ���� ũ�ν� ������ �۾� ���� ����
        }

        private void Btn_Connect_Click(object sender, EventArgs e)     //Connect ��ư�� ������ ���
        {
            ClientThread.ServerConnect(Txt_ServerIp.Text, Txt_ServerPort.Text, Txt_ClientIp.Text, Txt_ClientPort.Text);
        }

        private void Btn_IntSend_Click(object sender, EventArgs e)     //int Send ��ư�� ������ ���
        {
            ClientThread.IntDataSend(Convert.ToInt32(Txt_Int.Text));     //TextBox�� ������ �� Server�� ����
            Txt_Int.Text = string.Empty;
        }

        private void Btn_DoubleSend_Click(object sender, EventArgs e)  //double Send ��ư�� ������ ���
        {
            ClientThread.DoubleDataSend(Convert.ToDouble(Txt_Double.Text));  //TextBox�� ������ �� Server�� ����
            Txt_Double.Text = string.Empty;
        }

        private void Btn_StringSend_Click(object sender, EventArgs e)  //string Send ��ư�� ������ ���
        {
            ClientThread.StringDataSend(Txt_String.Text);  //TextBox�� ������ �� Server�� ����
            Txt_String.Text = string.Empty;
        }

        private void Btn_StructSend_Click(object sender, EventArgs e)  //Struct Send��ư�� ���� ���
        {
            ClientThread.SendSturctData(Convert.ToInt32(Txt_Int.Text), Convert.ToDouble(Txt_Double.Text), Txt_String.Text);
            Txt_Int.Text = string.Empty;
            Txt_Double.Text = string.Empty;
            Txt_String.Text = string.Empty;
        }

        private void Txt_Int_KeyPress(object sender, KeyPressEventArgs e)      //int textbox�� �Է��� ���
        {   //���ڸ� �Է°���
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; }
        }

        private void Txt_Double_KeyPress(object sender, KeyPressEventArgs e)   //double textbox�� �Է��� ���
        {   //���ڿ� '.' �Ѱ��� �Է°���
            if (Txt_Double.Text.Contains('.')) { if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; } }
            else { if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != 8) { e.Handled = true; } }
        }

        private void Txt_String_KeyPress(object sender, KeyPressEventArgs e)   //string textbox�� �Է��� ���
        {   //���ڸ� �Է� ����
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8) { e.Handled = true; }
        }
    }
}
