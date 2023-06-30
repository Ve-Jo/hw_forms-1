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
                label1.Text = "С новым годом!!";
            }
            else
            {
                label1.Text = string.Format("До Нового Года: {0} дней, {1} часов, {2} минут, {3} секунд",
                    remainingTime.Days, remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}