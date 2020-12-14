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
    public partial class izmen_ludi : Form
    {
        public izmen_ludi()
        {
            InitializeComponent();
        }

        private void izmen_ludi_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "select `ludi`.`FIO` from `ludi`";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["FIO"].ToString());
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
            label7.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            dateTimePicker1.Visible = true;
            button1.Visible = true;MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "select * from `ludi` where `ludi`.`FIO` = '"+comboBox1.SelectedItem.ToString()+"'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["Prava"].ToString();
                    textBox2.Text = reader["FIO"].ToString();
                    dateTimePicker1.Text = reader["Data_Rozhdenia"].ToString();
                    textBox3.Text = reader["Passport"].ToString();
                    textBox4.Text = reader["Nomer_telephona"].ToString();
                    textBox5.Text = reader["login"].ToString();
                    textBox6.Text = reader["pass"].ToString();
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
                string sql = "call update_ludi ('"+comboBox1.SelectedItem.ToString()+"','"+textBox1.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Изменения внесены!");
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
