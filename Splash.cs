namespace WeatherFeed
{
    public partial class Splash : Form
    {
        int count = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count <= 5)
            {
                this.Show();

            }
            else
            {
                Home home = new Home();
                home.Show();
                this.Hide();
                count = 0;
                timer1.Stop();
            }
        }
    }
}