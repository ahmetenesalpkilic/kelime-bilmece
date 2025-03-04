namespace WinFormsApp1
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Coolvetica Rg", 33F);
            label1.Location = new Point(231, 38);
            label1.Name = "label1";
            label1.Size = new Size(336, 66);
            label1.TabIndex = 1;
            label1.Text = "HOŞGELDİNİZ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(221, 115);
            label2.Name = "label2";
            label2.Size = new Size(355, 28);
            label2.TabIndex = 2;
            label2.Text = "Kaç farklı kelime gireceğinizi belirtiniz";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(321, 165);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Coolvetica Rg", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(172, 233);
            label3.Name = "label3";
            label3.Size = new Size(458, 28);
            label3.TabIndex = 4;
            label3.Text = "kelime sayısını girdikten sonra onaylaya tıklayın";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(335, 312);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "onayla";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Kelime Bilmece";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Button button1;
    }
}
