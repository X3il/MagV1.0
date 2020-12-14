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
    public partial class izmen_zhur : Form
    {
        public izmen_zhur()
        {
            InitializeComponent();
        }

        private void izmen_zhur_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call select_zhurnprod ()";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["№cheka"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button1.Visible = true;
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "CALL select_zhurn_poznach ('"+comboBox1.SelectedItem.ToString()+"')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["FIO"].ToString();
                    textBox2.Text = reader["Nazvanye"].ToString();
                    textBox3.Text = reader["Imya_pokupatelya"].ToString();
                    dateTimePicker1.Text = reader["Data_pokupki"].ToString();
                    dateTimePicker2.Text = reader["Data_dostavki"].ToString();
                    textBox4.Text = reader["kolichestvo_tovara"].ToString();
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
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call update_zhurn ('"+comboBox1.SelectedItem.ToString()+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Text+"','"+dateTimePicker2.Text+"','"+textBox4.Text+"')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Запись сохранена!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
