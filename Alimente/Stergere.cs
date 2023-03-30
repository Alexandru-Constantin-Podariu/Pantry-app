using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Alimente
{
    public partial class Stergere : Form
    {
        OleDbConnection conn;
        public Stergere()
        {
            InitializeComponent();
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=alimente.accdb";
            conn = new OleDbConnection(cs);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string q = "DELETE * FROM alimente WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }
    }
}
