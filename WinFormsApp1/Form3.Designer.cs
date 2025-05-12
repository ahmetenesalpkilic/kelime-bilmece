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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Coolvetica Rg", 33F);
            label2.Location = new Point(190, 24);
            label2.Name = "label2";
            label2.Size = new Size(399, 66);
            label2.TabIndex = 3;
            label2.Text = "KELİMELERİ BUL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(99, 209);
            label1.Name = "label1";
            label1.Size = new Size(160, 28);
            label1.TabIndex = 4;
            label1.Text = "İngilizce kelime :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(127, 254);
            label3.Name = "label3";
            label3.Size = new Size(101, 28);
            label3.TabIndex = 5;
            label3.Text = "Türkçesi :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(265, 256);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 27);
            textBox1.TabIndex = 6;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(265, 298);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(591, 244);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "başla";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(591, 291);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Değiştir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 452);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Form3";
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
    }
}