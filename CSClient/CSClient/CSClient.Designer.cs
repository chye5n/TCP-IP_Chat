namespace CSClient
{
    partial class CSClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            Btn_Connect = new Button();
            Txt_ClientPort = new TextBox();
            label6 = new Label();
            Txt_ServerPort = new TextBox();
            label2 = new Label();
            Txt_ClientIp = new TextBox();
            label7 = new Label();
            Txt_ServerIp = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            Btn_StringSend = new Button();
            Btn_DoubleSend = new Button();
            Btn_StructSend = new Button();
            Btn_IntSend = new Button();
            Txt_String = new TextBox();
            Txt_Double = new TextBox();
            label5 = new Label();
            label4 = new Label();
            Txt_Int = new TextBox();
            label3 = new Label();
            List_Receive = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Btn_Connect);
            groupBox1.Controls.Add(Txt_ClientPort);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(Txt_ServerPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_ClientIp);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(Txt_ServerIp);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 95);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "IP Setting";
            // 
            // Btn_Connect
            // 
            Btn_Connect.Font = new Font("맑은 고딕", 10F);
            Btn_Connect.Location = new Point(359, 24);
            Btn_Connect.Name = "Btn_Connect";
            Btn_Connect.Size = new Size(71, 55);
            Btn_Connect.TabIndex = 2;
            Btn_Connect.Text = "Connect";
            Btn_Connect.UseVisualStyleBackColor = true;
            Btn_Connect.Click += Btn_Connect_Click;
            // 
            // Txt_ClientPort
            // 
            Txt_ClientPort.Font = new Font("맑은 고딕", 10F);
            Txt_ClientPort.Location = new Point(265, 55);
            Txt_ClientPort.Name = "Txt_ClientPort";
            Txt_ClientPort.Size = new Size(86, 25);
            Txt_ClientPort.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11F);
            label6.Location = new Point(176, 57);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 0;
            label6.Text = "Client Port : ";
            // 
            // Txt_ServerPort
            // 
            Txt_ServerPort.Font = new Font("맑은 고딕", 10F);
            Txt_ServerPort.Location = new Point(265, 21);
            Txt_ServerPort.Name = "Txt_ServerPort";
            Txt_ServerPort.Size = new Size(86, 25);
            Txt_ServerPort.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11F);
            label2.Location = new Point(175, 23);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 0;
            label2.Text = "Server Port :";
            // 
            // Txt_ClientIp
            // 
            Txt_ClientIp.Font = new Font("맑은 고딕", 10F);
            Txt_ClientIp.Location = new Point(80, 56);
            Txt_ClientIp.Name = "Txt_ClientIp";
            Txt_ClientIp.Size = new Size(92, 25);
            Txt_ClientIp.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 11F);
            label7.Location = new Point(6, 58);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 0;
            label7.Text = "Client IP : ";
            // 
            // Txt_ServerIp
            // 
            Txt_ServerIp.Font = new Font("맑은 고딕", 10F);
            Txt_ServerIp.Location = new Point(80, 23);
            Txt_ServerIp.Name = "Txt_ServerIp";
            Txt_ServerIp.Size = new Size(92, 25);
            Txt_ServerIp.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F);
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "Server IP : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Btn_StringSend);
            groupBox2.Controls.Add(Btn_DoubleSend);
            groupBox2.Controls.Add(Btn_StructSend);
            groupBox2.Controls.Add(Btn_IntSend);
            groupBox2.Controls.Add(Txt_String);
            groupBox2.Controls.Add(Txt_Double);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Txt_Int);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("맑은 고딕", 10F);
            groupBox2.Location = new Point(12, 113);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 136);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Value";
            // 
            // Btn_StringSend
            // 
            Btn_StringSend.Font = new Font("맑은 고딕", 10F);
            Btn_StringSend.Location = new Point(225, 93);
            Btn_StringSend.Name = "Btn_StringSend";
            Btn_StringSend.Size = new Size(100, 30);
            Btn_StringSend.TabIndex = 2;
            Btn_StringSend.Text = "Send";
            Btn_StringSend.UseVisualStyleBackColor = true;
            Btn_StringSend.Click += Btn_StringSend_Click;
            // 
            // Btn_DoubleSend
            // 
            Btn_DoubleSend.Font = new Font("맑은 고딕", 10F);
            Btn_DoubleSend.Location = new Point(225, 56);
            Btn_DoubleSend.Name = "Btn_DoubleSend";
            Btn_DoubleSend.Size = new Size(100, 30);
            Btn_DoubleSend.TabIndex = 2;
            Btn_DoubleSend.Text = "Send";
            Btn_DoubleSend.UseVisualStyleBackColor = true;
            Btn_DoubleSend.Click += Btn_DoubleSend_Click;
            // 
            // Btn_StructSend
            // 
            Btn_StructSend.Font = new Font("맑은 고딕", 10F);
            Btn_StructSend.Location = new Point(346, 19);
            Btn_StructSend.Name = "Btn_StructSend";
            Btn_StructSend.Size = new Size(78, 104);
            Btn_StructSend.TabIndex = 2;
            Btn_StructSend.Text = "Struct Send";
            Btn_StructSend.UseVisualStyleBackColor = true;
            Btn_StructSend.Click += Btn_StructSend_Click;
            // 
            // Btn_IntSend
            // 
            Btn_IntSend.Font = new Font("맑은 고딕", 10F);
            Btn_IntSend.Location = new Point(225, 19);
            Btn_IntSend.Name = "Btn_IntSend";
            Btn_IntSend.Size = new Size(100, 30);
            Btn_IntSend.TabIndex = 2;
            Btn_IntSend.Text = "Send";
            Btn_IntSend.UseVisualStyleBackColor = true;
            Btn_IntSend.Click += Btn_IntSend_Click;
            // 
            // Txt_String
            // 
            Txt_String.Font = new Font("맑은 고딕", 10F);
            Txt_String.Location = new Point(99, 95);
            Txt_String.Name = "Txt_String";
            Txt_String.Size = new Size(100, 25);
            Txt_String.TabIndex = 1;
            Txt_String.KeyPress += Txt_String_KeyPress;
            // 
            // Txt_Double
            // 
            Txt_Double.Font = new Font("맑은 고딕", 10F);
            Txt_Double.Location = new Point(99, 58);
            Txt_Double.Name = "Txt_Double";
            Txt_Double.Size = new Size(100, 25);
            Txt_Double.TabIndex = 1;
            Txt_Double.KeyPress += Txt_Double_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11F);
            label5.Location = new Point(22, 97);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 0;
            label5.Text = "string : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 11F);
            label4.Location = new Point(22, 60);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 0;
            label4.Text = "double : ";
            // 
            // Txt_Int
            // 
            Txt_Int.Font = new Font("맑은 고딕", 10F);
            Txt_Int.Location = new Point(99, 21);
            Txt_Int.Name = "Txt_Int";
            Txt_Int.Size = new Size(100, 25);
            Txt_Int.TabIndex = 1;
            Txt_Int.KeyPress += Txt_Int_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11F);
            label3.Location = new Point(22, 23);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 0;
            label3.Text = "int : ";
            // 
            // List_Receive
            // 
            List_Receive.FormattingEnabled = true;
            List_Receive.ItemHeight = 15;
            List_Receive.Location = new Point(12, 259);
            List_Receive.Name = "List_Receive";
            List_Receive.Size = new Size(445, 154);
            List_Receive.TabIndex = 2;
            // 
            // CSClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 425);
            Controls.Add(List_Receive);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CSClient";
            Text = "CSClient";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button Btn_Connect;
        private TextBox Txt_ServerPort;
        private Label label2;
        private TextBox Txt_ServerIp;
        private GroupBox groupBox2;
        private Button Btn_StringSend;
        private Button Btn_DoubleSend;
        private Button Btn_StructSend;
        private Button Btn_IntSend;
        private TextBox Txt_String;
        private TextBox Txt_Double;
        private Label label5;
        private Label label4;
        private TextBox Txt_Int;
        private Label label3;
        private TextBox Txt_ClientPort;
        private Label label6;
        private TextBox Txt_ClientIp;
        private Label label7;
        public ListBox List_Receive;
    }
}
