namespace BatteryAppGUI
{
    public partial class MainWindow : Form
    {

        protected override bool ProcessDialogKey(Keys keyData) {
            if (keyData == Keys.Escape) {
                Close();
                return true;
            } else
                return base.ProcessDialogKey(keyData);
        }

        public MainWindow() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            //WipeAllFields("N/A");

            var result = new DataProcessing();
            optimallabel.Text = $"{result.OptimalCount}";
            badlabel.Text = $"{result.BadCount}";
            spotlabel.Text = $"{result.SpotCount}";
            droplabel.Text = $"{result.Drop} %";
            timelabel.Text = $"{(result.Time / 60):0.##} mins";
        }

        private void Cookbutton_Click(object sender, EventArgs e) {
            var result = new DataProcessing();
            optimallabel.Text = $"{result.OptimalCount}";
            badlabel.Text = $"{result.BadCount}";
            spotlabel.Text = $"{result.SpotCount}";
            droplabel.Text = $"{result.Drop} %";
            timelabel.Text = $"{(result.Time / 60):0.##} mins";

        }

        private void Clearbutton_Click(object sender, EventArgs e) {
            WipeAllFields("N/A");

        }
        private void WipeAllFields(string arg) {
            optimallabel.Text = arg;
            badlabel.Text = arg;
            spotlabel.Text = arg;
            droplabel.Text = arg;
            timelabel.Text = arg;

        }


    }
}
