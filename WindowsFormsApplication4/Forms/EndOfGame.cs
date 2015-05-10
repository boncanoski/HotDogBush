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
    public partial class EndOfGame : Form
    {
        public EnterData EnterData { get; set; }
        public int score { get; set; }
        List<EnterData> enterDataList;
        public EndOfGame()
        {
            score = 0;
            InitializeComponent();
            enterDataList = new List<EnterData>();
            using (StreamReader Reader = new StreamReader(@"scores.txt"))
            {
                var names = new List<string>();
                while (!Reader.EndOfStream)
                {
                    string s = Reader.ReadLine();
                    enterDataList.Add(new EnterData(s.Substring(0, s.IndexOf(';')), int.Parse(s.Substring(s.IndexOf(';') + 1))));
                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (txtIme.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtIme, "задолжително поле");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterData = new EnterData(txtIme.Text, this.score);
            writeInFile(EnterData);
            HighScores highScores = new HighScores();
            highScores.Show();
            this.Close();
        }

        private void writeInFile(EnterData item)
        {
            enterDataList.Add(item);
            enterDataList.Sort(); // gi podreduva po iComparable deka ima implementirano po poeni
            for (int i = enterDataList.Count - 1; i >= 10; i--)
                enterDataList.RemoveAt(i); // gi brise site od deset nagore, prvo gi sortira 

            using (StreamWriter Writer = new StreamWriter(@"scores.txt", false))
            {
                foreach (var i in enterDataList)
                {
                    Writer.WriteLine(i.Ime + ";" + i.Poeni);
                }
                Writer.Close();
            }
        }
    }
}
