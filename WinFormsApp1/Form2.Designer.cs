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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(354, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
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
            label5.Location = new Point(548, 190);
            label5.Name = "label5";
            label5.Size = new Size(134, 23);
            label5.TabIndex = 9;
            label5.Text = "Kelime sayısı : 0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(185, 307);
            label4.Name = "label4";
            label4.Size = new Size(469, 20);
            label4.TabIndex = 10;
            label4.Text = "Kelimenin ingilizcesini ardından türkçesini girdikten sonra enter'a tıkla";
            // 
            // button2
            // 
            button2.Location = new Point(354, 352);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "onayla";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}