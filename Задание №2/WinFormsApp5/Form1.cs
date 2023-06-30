namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private Random random;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            int buttonWidth = button1.Width;
            int buttonHeight = button1.Height;

            int formWidth = this.ClientSize.Width - buttonWidth;
            int formHeight = this.ClientSize.Height - buttonHeight;

            int newX = random.Next(formWidth);
            int newY = random.Next(formHeight);

            button1.Location = new Point(newX, newY);
        }
    }
}