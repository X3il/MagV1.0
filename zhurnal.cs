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
    public partial class zhurnal : Form
    {
        public zhurnal()
        {
            InitializeComponent();
        }

        private void zhurnal_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_zhurnprod ()";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                //MassageBox.Show("Подключено");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["№cheka"].ToString(), reader["FIO"].ToString(), reader["Nazvanye"].ToString(), reader["Imya_pokupatelya"].ToString(), reader["Data_pokupki"].ToString(), reader["Data_dostavki"].ToString(), reader["kolichestvo_tovara"].ToString(),reader["itogo"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newform = new dobav_zhurn();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = DBConn.GetDBConnection();
                conn.Open();
                string sql = "DELETE FROM `Zhyrnal_prodazh` WHERE `Zhyrnal_prodazh`.`№cheka` = '" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Запись удалена!");
                button3_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления" + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_zhurnprod ()";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader;
                //MassageBox.Show("Подключено");
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["№cheka"].ToString(), reader["FIO"].ToString(), reader["Nazvanye"].ToString(), reader["Imya_pokupatelya"].ToString(), reader["Data_pokupki"].ToString(), reader["Data_dostavki"].ToString(), reader["kolichestvo_tovara"].ToString(), reader["itogo"].ToString());
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
            Form newform = new izmen_zhur();
            newform.Show();
        }

        private void zhurnal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
