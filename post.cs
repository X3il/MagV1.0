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
    public partial class post : Form
    {
        public post()
        {
            InitializeComponent();
        }

        private void post_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_post";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Nazvanie_post"].ToString(), reader["Direktor"].ToString(), reader["Zakreplennyi_sklad"].ToString());
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
            MySqlConnection conn = DBConn.GetDBConnection();

            try
            {
                conn.Open();
                string sql = "DELETE FROM `Postavshiki` WHERE `Postavshiki`.`Nazvanie_post` = '"+dataGridView1[0,dataGridView1.CurrentRow.Index].Value.ToString()+"'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Запись удалена!");
                button3_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newform = new dobav_post();
            newform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_post";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                //MassageBox.Show("Подключено");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add( reader["Nazvanie_post"].ToString(), reader["Direktor"].ToString(), reader["Zakreplennyi_sklad"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form newform = new izmen_post();
            newform.Show();
        }
    }
    
}
