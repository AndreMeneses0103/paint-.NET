using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {

        public static int espessura = 1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            espessura = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            espessura = 2;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            espessura = 3;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            espessura = 4;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            espessura = 5;
            this.Close();
        }
    }
}
