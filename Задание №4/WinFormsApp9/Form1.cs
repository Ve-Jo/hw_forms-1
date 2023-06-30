using System.Drawing;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        private int clickCount;
        private int maxClicks;
        private int remainingSeconds;

        private List<Color> colors;
        private int colorIndex;
        private bool isColorChanging;

        public Form1()
        {
            InitializeComponent();

            clickCount = 0;
            maxClicks = 0;
            remainingSeconds = 20;

            timer1.Interval = 1000;
            timer2.Interval = 100;

            colors = new List<Color>
            {
                Color.Black,
                Color.Red,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Blue,
                Color.Pink,
                Color.White
            };
            colorIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "Таймер запущен!";
            }
            clickCount++;
            label1.Text = clickCount.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            UpdateButtonLabel();
            if (remainingSeconds <= 0)
            {
                timer1.Enabled = false;
                if (clickCount > maxClicks)
                    maxClicks = clickCount;
                MessageBox.Show($"Сделано кликов: {clickCount}\nВаш рекорд: {maxClicks}");
                clickCount = 0;
                label1.Text = "0";
                button1.Text = "Начать кликать";
                remainingSeconds = 20;
            }
        }

        private void UpdateButtonLabel()
        {
            button1.Text = $"Таймер ({remainingSeconds} секунд)";
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            if (!isColorChanging)
            {
                colorIndex++;
                if (colorIndex >= colors.Count)
                    colorIndex = 0;

                await ChangeBackgroundColorAsync(colors[colorIndex]);
            }
        }

        private async Task ChangeBackgroundColorAsync(Color color)
        {
            isColorChanging = true;
            int steps = 50;
            int delay = 10;
            int rStep = (color.R - this.BackColor.R) / steps;
            int gStep = (color.G - this.BackColor.G) / steps;
            int bStep = (color.B - this.BackColor.B) / steps;

            for (int i = 0; i < steps; i++)
            {
                int r = this.BackColor.R + rStep;
                int g = this.BackColor.G + gStep;
                int b = this.BackColor.B + bStep;
                this.BackColor = Color.FromArgb(r, g, b);
                await Task.Delay(delay);
            }

            this.BackColor = color;
            isColorChanging = false;
        }
    }
}