namespace CSServer
{
    partial class CSServer
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
            Txt_Ip = new TextBox();
            label1 = new Label();
            Txt_Port = new TextBox();
            label2 = new Label();
            Btn_Connect = new Button();
            Txt_Int = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            Txt_String = new TextBox();
            Btn_StringSend = new Button();
            Btn_DoubleSend = new Button();
            Btn_StructSend = new Button();
            Btn_IntSend = new Button();
            label5 = new Label();
            Txt_Double = new TextBox();
            label4 = new Label();
            List_Receive = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Txt_Ip
            // 
            Txt_Ip.Font = new Font("맑은 고딕", 10F);
            Txt_Ip.Location = new Point(52, 27);
            Txt_Ip.Name = "Txt_Ip";
            Txt_Ip.Size = new Size(100, 25);
            Txt_Ip.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F);
            label1.Location = new Point(16, 29);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 1;
            label1.Text = "IP : ";
            // 
            // Txt_Port
            // 
            Txt_Port.Font = new Font("맑은 고딕", 10F);
            Txt_Port.Location = new Point(209, 27);
            Txt_Port.Name = "Txt_Port";
            Txt_Port.Size = new Size(100, 25);
            Txt_Port.TabIndex = 0;
            Txt_Port.KeyPress += Txt_Int_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11F);
            label2.Location = new Point(159, 29);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Port : ";
            // 
            // Btn_Connect
            // 
            Btn_Connect.Location = new Point(327, 24);
            Btn_Connect.Name = "Btn_Connect";
            Btn_Connect.Size = new Size(100, 30);
            Btn_Connect.TabIndex = 2;
            Btn_Connect.Text = "Connect";
            Btn_Connect.UseVisualStyleBackColor = true;
            Btn_Connect.Click += Btn_Connect_Click;
            // 
            // Txt_Int
            // 
            Txt_Int.Font = new Font("맑은 고딕", 10F);
            Txt_Int.Location = new Point(99, 21);
            Txt_Int.Name = "Txt_Int";
            Txt_Int.Size = new Size(100, 25);
            Txt_Int.TabIndex = 0;
            Txt_Int.KeyPress += Txt_Int_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11F);
            label3.Location = new Point(22, 23);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 1;
            label3.Text = "int : ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Btn_Connect);
            groupBox1.Controls.Add(Txt_Ip);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_Port);
            groupBox1.Font = new Font("맑은 고딕", 10F);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(445, 69);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "IP Setting";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Txt_String);
            groupBox2.Controls.Add(Btn_StringSend);
            groupBox2.Controls.Add(Btn_DoubleSend);
            groupBox2.Controls.Add(Btn_StructSend);
            groupBox2.Controls.Add(Btn_IntSend);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(Txt_Double);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Txt_Int);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("맑은 고딕", 10F);
            groupBox2.Location = new Point(12, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(445, 136);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Value";
            // 
            // Txt_String
            // 
            Txt_String.Font = new Font("맑은 고딕", 10F);
            Txt_String.Location = new Point(99, 95);
            Txt_String.Name = "Txt_String";
            Txt_String.Size = new Size(100, 25);
            Txt_String.TabIndex = 0;
            Txt_String.KeyPress += Txt_String_KeyPress;
            // 
            // Btn_StringSend
            // 
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
            Btn_IntSend.Location = new Point(225, 19);
            Btn_IntSend.Name = "Btn_IntSend";
            Btn_IntSend.Size = new Size(100, 30);
            Btn_IntSend.TabIndex = 2;
            Btn_IntSend.Text = "Send";
            Btn_IntSend.UseVisualStyleBackColor = true;
            Btn_IntSend.Click += Btn_IntSend_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11F);
            label5.Location = new Point(22, 97);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 1;
            label5.Text = "string : ";
            // 
            // Txt_Double
            // 
            Txt_Double.Font = new Font("맑은 고딕", 10F);
            Txt_Double.Location = new Point(99, 58);
            Txt_Double.Name = "Txt_Double";
            Txt_Double.Size = new Size(100, 25);
            Txt_Double.TabIndex = 0;
            Txt_Double.KeyPress += Txt_Double_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 11F);
            label4.Location = new Point(22, 60);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 1;
            label4.Text = "double : ";
            // 
            // List_Receive
            // 
            List_Receive.FormattingEnabled = true;
            List_Receive.ItemHeight = 15;
            List_Receive.Location = new Point(12, 234);
            List_Receive.Name = "List_Receive";
            List_Receive.Size = new Size(445, 154);
            List_Receive.TabIndex = 6;
            // 
            // CSServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 398);
            Controls.Add(List_Receive);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CSServer";
            Text = "CSServer";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox Txt_Ip;
        private Label label1;
        private TextBox Txt_Port;
        private Label label2;
        private Button Btn_Connect;
        private TextBox Txt_Int;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox Txt_String;
        private Label label5;
        private TextBox Txt_Double;
        private Label label4;
        private Button Btn_StringSend;
        private Button Btn_DoubleSend;
        private Button Btn_IntSend;
        private Button Btn_StructSend;
        public ListBox List_Receive;
    }
}
