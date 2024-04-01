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
            Txt_Ip.Text = IPAddressSetting.GetIp();                     //���� IP �Է�, AddressList[1] = xxx.xxx.xxx.xxx
            Txt_Port.Text = "4000";                                     //Server ���� ��Ʈ
            CheckForIllegalCrossThreadCalls = false;                    //UI ��Ʈ�� ������Ʈ�� ���� ũ�ν� ������ �۾� ���� ����
        }

        private void Btn_Connect_Click(object sender, EventArgs e)  //Connect,��ư�� ���� ���
        {
            TcpThread.StartServer(Txt_Ip.Text, Txt_Port.Text);                                          //������ ����, TCP Listener ����
            Btn_Connect.Enabled = false;                            //������ ������ �� ��� Connect��ư ��Ȱ��ȭ
            List_Receive.Items.Add("������ ���۵Ǿ����ϴ�.\n");     //���� ���� �޽��� ǥ��
        }

        private void Btn_IntSend_Click(object sender, EventArgs e)     //int Send��ư�� ���� ���
        {
            TcpThread.IntDataSend(Convert.ToInt32(Txt_Int.Text));     //TextBox�� ������ �� C# Client�� ����
            Txt_Int.Text = string.Empty;          //������ ���� �� txt�� �ؽ�Ʈ �ʱ�ȭ
        }

        private void Btn_DoubleSend_Click(object sender, EventArgs e)  //double Send��ư�� ���� ���
        {
            TcpThread.DoubleDataSend(Convert.ToDouble(Txt_Double.Text));  //TextBox�� ������ �� Client�� ����
            Txt_Double.Text = string.Empty;       //������ ���� �� txt�� �ؽ�Ʈ �ʱ�ȭ
        }

        private void Btn_StringSend_Click(object sender, EventArgs e)  //string Send��ư�� ���� ���
        {
            TcpThread.StringDataSend(Txt_String.Text);  //TextBox�� ������ �� Client�� ����
            Txt_String.Text = string.Empty;       //������ ���� �� txt�� �ؽ�Ʈ �ʱ�ȭ
        }

        private void Btn_StructSend_Click(object sender, EventArgs e)  //Struct Send��ư�� ���� ���
        {
            TcpThread.SturctDataSend(Convert.ToInt32(Txt_Int.Text), Convert.ToDouble(Txt_Double.Text), Txt_String.Text);
            Txt_Int.Text = string.Empty;          //������ ���� �� txt�� �ؽ�Ʈ �ʱ�ȭ
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
