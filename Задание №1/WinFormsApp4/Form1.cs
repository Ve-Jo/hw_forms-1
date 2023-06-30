namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private bool isMouseDown;
        private Point startPoint;
        private List<Button> resizableButtons;
        private int buttonCounter;

        public Form1()
        {
            InitializeComponent();
            isMouseDown = false;
            resizableButtons = new List<Button>();
            buttonCounter = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                startPoint = e.Location;
                CreateResizableButton();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && resizableButtons.Count > 0)
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int width = Math.Abs(e.X - startPoint.X);
                int height = Math.Abs(e.Y - startPoint.Y);

                resizableButtons[resizableButtons.Count - 1].Location = new Point(x, y);
                resizableButtons[resizableButtons.Count - 1].Size = new Size(width, height);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void CreateResizableButton()
        {
            Button resizableButton = new Button();
            resizableButton.Location = startPoint;
            resizableButton.Size = new Size(0, 0);
            resizableButton.Text = "button" + buttonCounter;
            buttonCounter++;

            this.Controls.Add(resizableButton);
            resizableButtons.Add(resizableButton);
        }
    }
}