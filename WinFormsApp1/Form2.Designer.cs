namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(354, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Coolvetica Rg", 33F);
            label2.Location = new Point(156, 54);
            label2.Name = "label2";
            label2.Size = new Size(495, 66);
            label2.TabIndex = 2;
            label2.Text = "KELİMELERİ BELİRLE";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(185, 160);
            label1.Name = "label1";
            label1.Size = new Size(154, 28);
            label1.TabIndex = 3;
            label1.Text = "ingilizce kelime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(156, 225);
            label3.Name = "label3";
            label3.Size = new Size(192, 28);
            label3.TabIndex = 4;
            label3.Text = "kelimenin türkçesi :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(354, 226);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Coolvetica Rg", 11.2000008F);
            label5.Location = new Point(525, 185);
            label5.Name = "label5";
            label5.Size = new Size(200, 23);
            label5.TabIndex = 9;
            label5.Text = "Eklenen kelime sayısı : 0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(179, 282);
            label4.Name = "label4";
            label4.Size = new Size(472, 40);
            label4.TabIndex = 10;
            label4.Text = "Kelimenin ingilizcesini ardından türkçesini girdikten sonra enter'a tıkla.\r\n         Gireceğiniz kelimeler bitti ise onayla butonuna tıklayınız!\r\n";
            // 
            // button2
            // 
            button2.Location = new Point(354, 346);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "onayla";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(568, 226);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 12;
            button1.Text = "geri al";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(299, 391);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 27);
            textBox3.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(286, 431);
            label6.Name = "label6";
            label6.Size = new Size(238, 40);
            label6.TabIndex = 14;
            label6.Text = "        Kelimelerin kaydolacağı \r\nmetin belgesinin ismini belirleyiniz";
            // 
            // button3
            // 
            button3.Location = new Point(539, 391);
            button3.Name = "button3";
            button3.Size = new Size(205, 29);
            button3.TabIndex = 15;
            button3.Text = "kaydet ve devam et";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonFace;
            button4.ForeColor = SystemColors.ActiveCaptionText;
            button4.Location = new Point(8, 12);
            button4.Name = "button4";
            button4.Size = new Size(178, 29);
            button4.TabIndex = 16;
            button4.Text = "🠔 Bir Önceki Sayfa";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(41, 390);
            button5.Name = "button5";
            button5.Size = new Size(204, 29);
            button5.TabIndex = 17;
            button5.Text = "Metin Belgesi Seç";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(48, 427);
            label7.Name = "label7";
            label7.Size = new Size(192, 40);
            label7.TabIndex = 18;
            label7.Text = "Bir metin belgesinin üstüne \r\n      yazmak için tıklayın!";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(12, 44);
            label8.Name = "label8";
            label8.Size = new Size(317, 20);
            label8.TabIndex = 19;
            label8.Text = "Şu anda bir metin belgesi üstüne yazıyorsunuz!\r\n";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 515);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "Kelimeleri belirle";
            FormClosing += Form2_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private Button button2;
        private Button button1;
        private TextBox textBox3;
        private Label label6;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label7;
        private Label label8;
    }
}