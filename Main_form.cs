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
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }
        private void Main_form_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                string sql = "call select_ludi";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Prava"].ToString(), reader["FIO"].ToString(), reader["Data_Rozhdenia"].ToString(), reader["Passport"].ToString(), reader["Nomer_telephona"].ToString(), reader["login"].ToString(), reader["pass"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBConn.GetDBConnection();
                conn.Open();
                string sql = "DELETE FROM `ludi` WHERE `ludi`.`FIO` = '" + dataGridView1[1,dataGridView1.CurrentRow.Index].Value.ToString() + "'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Запись удалена!");
                button3_Click(null,null);
            }
            catch ( Exception ex)
            {
                MessageBox.Show("Ошибка удаления" + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                dataGridView1.Rows.Clear();
                conn.Open();
                string sql = "call select_ludi";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Prava"].ToString(), reader["FIO"].ToString(), reader["Data_Rozhdenia"].ToString(), reader["Passport"].ToString(), reader["Nomer_telephona"].ToString(), reader["login"].ToString(), reader["pass"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form newform = new dobav_ludi();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form nwform = new izmen_ludi();
            nwform.Show();
        }

        
    }
}
