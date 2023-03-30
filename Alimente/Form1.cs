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
    public partial class Form1 : Form
    {
        OleDbConnection conn;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=alimente.accdb";
            conn = new OleDbConnection(cs);
            conn.Open();
            string q = "SELECT * from alimente";
            OleDbCommand c = new OleDbCommand(q, conn);
            OleDbDataReader dr = c.ExecuteReader();
            comboBox1.Items.Clear();
            string cat = null;
            while (dr.Read())
            {
                
                if(cat!=dr[1].ToString())
                {
                    comboBox1.Items.Add(dr[1].ToString());
                    comboBox2.Items.Add(dr[1].ToString());
                    comboBox3.Items.Add(dr[1].ToString());
                }
                    
                cat=dr[1].ToString();
            }
                
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //afisare
            string cat = comboBox1.Text;
            string q = "SELECT * FROM alimente WHERE CATEGORIE='"+cat+"'";
            OleDbCommand c = new OleDbCommand(q, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(c);
            DataTable t = new DataTable();
            da.Fill(t);
            dataGridView1.DataSource = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adaugare
            string NULL = "";
            string categorie_existenta = comboBox2.Text;
            string categorie_noua = textBox1.Text;
            string brand = textBox2.Text;
            string denumire = textBox3.Text;
            int cantitate = int.Parse(textBox4.Text);
            string data_expirarii =dateTimePicker1.Text;
            string q = "INSERT INTO alimente(CATEGORIE,BRAND,DENUMIRE,CANTITATE,DATA_EXPIRARII) VALUES";
            if(categorie_noua!=NULL)
            {
                q+="('"+categorie_noua+ "','" + brand + "','" + denumire + "'," + cantitate + ",'" + data_expirarii + "')";
                comboBox1.Items.Add(textBox1.Text);
                comboBox2.Items.Add(textBox1.Text);
                comboBox3.Items.Add(textBox1.Text);
            }             
            else
                q += "('" + categorie_existenta + "','" + brand + "','" + denumire + "'," + cantitate + ",'" + data_expirarii + "')";
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender,e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //modifică categoria
            int id = int.Parse(textBox8.Text);
            string categorie = comboBox3.Text;
            string q = "UPDATE alimente SET CATEGORIE='" + categorie + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender,e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //modifică denumirea
            int id = int.Parse(textBox8.Text);
            string denumire = textBox6.Text;
            string q = "UPDATE alimente SET DENUMIRE='" + denumire + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //modifică cantitatea
            int id = int.Parse(textBox8.Text);
            int cantitate= int.Parse(textBox5.Text);
            string q = "UPDATE alimente SET CANTITATE=" + cantitate + " WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //modifică data expirarii
            int id = int.Parse(textBox8.Text);
            string data_expirarii = dateTimePicker2.Text;
            string q = "UPDATE alimente SET DATA_EXPIRARII='" + data_expirarii + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //stergere
            int id = int.Parse(textBox9.Text);
            string q = "DELETE * FROM alimente WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender, e);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //modifică brand-ul
            int id = int.Parse(textBox8.Text);
            string brand = textBox7.Text;
            string q = "UPDATE alimente SET BRAND='" + brand + "' WHERE ID=" + id;
            OleDbCommand c = new OleDbCommand(q, conn);
            c.ExecuteNonQuery();
            button2_Click(sender, e);
        }
    }
}
