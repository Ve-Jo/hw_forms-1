namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        private DateTime newYear;
        public Form1()
        {
            InitializeComponent();
            newYear = new DateTime(DateTime.Now.Year + 1, 1, 1);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = newYear - DateTime.Now;

            if (remainingTime.TotalSeconds <= 0)
            {
                timer1.Stop();
                label1.Text = "� ����� �����!!";
            }
            else
            {
                label1.Text = string.Format("�� ������ ����: {0} ����, {1} �����, {2} �����, {3} ������",
                    remainingTime.Days, remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}