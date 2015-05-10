using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotDogBush
{
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader Reader = new StreamReader(@"scores.txt"))
            {
                var names = new List<string>();
                while (!Reader.EndOfStream)
                {
                    string s = Reader.ReadLine();
                    string[] prv = s.Split(';');
                    string print = string.Format("{0,-60} {1}", prv[0], prv[1]);
                    listBox1.Items.Add(print);
                }
            }
        }
    }
}
