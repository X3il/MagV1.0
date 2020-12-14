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
    public partial class dobav_zhurn : Form
    {
        public dobav_zhurn()
        {
            InitializeComponent();
        }

        private void dobav_zhurn_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();
            try
            {
                conn.Open();
                string sql = "call insert_zhurn ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Новая покупка добавлена!");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Ошибка, возможно такая покупка уже существует ¯|_(ツ)_|¯");
            }
        }
    }
}
