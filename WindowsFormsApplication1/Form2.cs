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
    public partial class Form2 : Form
    {
        public static float[] traco = {1};
        public Form2()
        {
            InitializeComponent();
        }

        //Tracejado Solid
        private void button1_Click(object sender, EventArgs e)
        {
            traco = new float[]{1};
            this.Close();
        }

        //Tracejado Dash
        private void button2_Click(object sender, EventArgs e)
        {
            traco = new float[] {5,1};
            this.Close();
        }

        //Tracejado Dot
        private void button3_Click(object sender, EventArgs e)
        {
            traco = new float[] { 1, 2 };
            this.Close();
        }

        //Tracejado DashDot
        private void button4_Click(object sender, EventArgs e)
        {
            traco = new float[] { 5, 1, 1, 1 };
            this.Close();
        }

        //Tracejado DashDotDot
        private void button5_Click(object sender, EventArgs e)
        {
            traco = new float[] { 5, 1, 1, 1, 1, 1 };
            this.Close();

        }
    }
}
