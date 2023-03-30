using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alimente
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new  Form1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adaugare f = new Adaugare();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stergere f = new Stergere();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modificare f = new Modificare();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}
