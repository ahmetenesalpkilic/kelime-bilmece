namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int kelimesayisi;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kelimesayisi = Convert.ToInt32(textBox1.Text);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(kelimesayisi);
            this.Hide();
            f2.ShowDialog();
        }
    }
}
