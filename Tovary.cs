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
    public partial class Tovary : Form
    {
        public Tovary()
        {
            InitializeComponent();
        }

        private void Tovary_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_tov ()";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                //MassageBox.Show("Подключено");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Nazvanye"].ToString(), reader["Nazvanie_post"].ToString(), reader["chena_zakupki"].ToString(),reader["chena"].ToString(),reader["Srok_godnosti"].ToString(),reader["Kolichestvo"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            dataGridView1.Rows.Clear();
            try
            {
                conn.Open();
                string sql = "call select_tov ()";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                //MassageBox.Show("Подключено");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add( reader["Nazvanye"].ToString(), reader["Nazvanie_post"].ToString(), reader["chena_zakupki"].ToString(), reader["chena"].ToString(), reader["Srok_godnosti"].ToString(), reader["Kolichestvo"].ToString());
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
            Form newform = new izmen_tov();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newform = new dobav_tov();
            newform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "delete from `Tovaru` where `Tovaru`.`Nazvanye` = '"+dataGridView1[0,dataGridView1.CurrentRow.Index].Value.ToString()+"'";
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
    }
}
