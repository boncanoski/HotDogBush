using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotDogBush
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Instructions ins = new Instructions();
            ins.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            g.home = this;
            g.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HighScores highScores = new HighScores();
            highScores.Show();
        }
    }
}
