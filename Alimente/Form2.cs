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
    public partial class Form2 : Form
    {
        OleDbConnection conn;
        public Form2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=alimente.accdb";
            conn = new OleDbConnection(cs);
            conn.Open();
            DateTime d1 = dateTimePicker1.Value;
            int Month = d1.Month+1;
            int Day = 1;
            int Year = d1.Year;
            if(Month==13)
            {
                Month = 1;
                Year++;
            }
            string q = "SELECT * FROM alimente WHERE DATA_EXPIRARII<#" + Month +
                "/" + Day + "/" + Year + "#";
            q+= "AND DATA_EXPIRARII>=#" + d1.Month +
                "/" + Day + "/" + d1.Year + "#";
            OleDbCommand c = new OleDbCommand(q, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(c);
            DataTable t = new DataTable();
            da.Fill(t);
            dataGridView1.DataSource = t;
            string date = dateTimePicker1.Text;
            string q1 = "SELECT * FROM alimente WHERE DATA_EXPIRARII<#" + date + "#";
            OleDbCommand c1 = new OleDbCommand(q1, conn);
            OleDbDataAdapter da1 = new OleDbDataAdapter(c1);
            DataTable t1 = new DataTable();
            da1.Fill(t1);
            dataGridView2.DataSource = t1;


        }
    }
}
