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
    public partial class Modificare : Form
    {
        OleDbConnection conn;
        public Modificare()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=alimente.accdb";
            conn = new OleDbConnection(cs);
            conn.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //modifică categoria
            string NULL = "";
            int id = int.Parse(textBox8.Text);
            string categorie_noua = textBox1.Text;
            string categorie_existenta = comboBox2.Text;
            string categorie = "";
            if (categorie_noua != NULL) categorie = categorie_noua;
            else categorie = categorie_existenta;
            string q = "UPDATE alimente SET CATEGORIE='" + categorie + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //modifică brand-ul
            int id = int.Parse(textBox8.Text);
            string brand = textBox7.Text;
            string q = "UPDATE alimente SET BRAND='" + brand + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //modifică denumirea
            int id = int.Parse(textBox8.Text);
            string denumire = textBox6.Text;
            string q = "UPDATE alimente SET DENUMIRE='" + denumire + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //modifică cantitatea
            int id = int.Parse(textBox8.Text);
            int cantitate = int.Parse(textBox5.Text);
            string q = "UPDATE alimente SET CANTITATE=" + cantitate + " WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //modifică data expirarii
            int id = int.Parse(textBox8.Text);
            string data_expirarii = dateTimePicker2.Text;
            string q = "UPDATE alimente SET DATA_EXPIRARII='" + data_expirarii + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
