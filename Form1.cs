using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            ekleme fr = new ekleme();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele fr = new listele();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sil fr = new sil();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            düzenle fr = new düzenle();
            fr.Show();
        }

    }
}
