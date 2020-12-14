using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mag
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                MessageBox.Show("Подключено");
                conn.Close();
                Form fg = new Form1();
                fg.Show();
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                

            }
        }
    }
}
