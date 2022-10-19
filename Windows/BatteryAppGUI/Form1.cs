using Processing;
using System.Diagnostics;

namespace BatteryAppGUI
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            WipeAllFields("N/A");
        }

        private void Cookbutton_Click(object sender, EventArgs e) {
            var result =  new Processed();
            optimallabel.Text = $"{result._optimalCount}";
            badlabel.Text = $"{result._badCount}";
            spotlabel.Text = $"{result._spotCount}";
            droplabel.Text = $"{result._drop} %";
            timelabel.Text = $"{(result._time / 60):0.##} mins";

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