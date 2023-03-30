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
    public partial class Adaugare : Form
    {
        OleDbConnection conn;
        public Adaugare()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=alimente.accdb";
            conn = new OleDbConnection(cs);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NULL = "";
            string categorie_existenta = comboBox2.Text;
            string categorie_noua = textBox1.Text;
            string brand = textBox2.Text;
            string denumire = textBox3.Text;
            int cantitate = int.Parse(textBox4.Text);
            string data_expirarii = dateTimePicker1.Text;
            string q = "INSERT INTO alimente(CATEGORIE,BRAND,DENUMIRE,CANTITATE,DATA_EXPIRARII) VALUES";
            if (categorie_noua != NULL)
            {
                q += "('" + categorie_noua + "','" + brand + "','" + denumire + "'," + cantitate + ",'" + data_expirarii + "')";
                comboBox2.Items.Add(textBox1.Text);
            }
            else
                q += "('" + categorie_existenta + "','" + brand + "','" + denumire + "'," + cantitate + ",'" + data_expirarii + "')";
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
        }
    }
}
