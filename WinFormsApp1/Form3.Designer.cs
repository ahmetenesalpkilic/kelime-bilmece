namespace WinFormsApp1
{
    partial class Form3
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            checkBox1 = new CheckBox();
            button3 = new Button();
            label5 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Coolvetica Rg", 33F);
            label2.Location = new Point(256, 34);
            label2.Name = "label2";
            label2.Size = new Size(399, 66);
            label2.TabIndex = 3;
            label2.Text = "KELİMELERİ BUL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(152, 244);
            label1.Name = "label1";
            label1.Size = new Size(160, 28);
            label1.TabIndex = 4;
            label1.Text = "İngilizce kelime :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(180, 289);
            label3.Name = "label3";
            label3.Size = new Size(101, 28);
            label3.TabIndex = 5;
            label3.Text = "Türkçesi :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(318, 291);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 27);
            textBox1.TabIndex = 6;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 333);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(706, 291);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "başla";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(706, 338);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Değiştir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(554, 261);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(123, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "Türkçesini gör";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button3
            // 
            button3.Location = new Point(707, 413);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 13;
            button3.Text = "Kelime Sil";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(656, 445);
            label5.Name = "label5";
            label5.Size = new Size(206, 40);
            label5.TabIndex = 14;
            label5.Text = "     Eğer kelimeyi listeden \r\nkaldırmak istiyorsanız tıklayın!";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(42, 465);
            label8.Name = "label8";
            label8.Size = new Size(276, 20);
            label8.TabIndex = 20;
            label8.Text = "Hangi metin belgesi acıldı bilgilendirme";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 560);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KELİMELERİ BUL";
            FormClosing += Form3_FormClosing;
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button button2;
        private Button button1;
        private CheckBox checkBox1;
        private Button button3;
        private Label label5;
        private Label label8;
    }
}