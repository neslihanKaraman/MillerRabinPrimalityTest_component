using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MillerRabinPrimalityTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = myMillerRabinPrimalityTest.sayi.ToString();
            textBox2.Text = myMillerRabinPrimalityTest.k.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myMillerRabinPrimalityTest.sonuc.ToString());
        }
    }
}
