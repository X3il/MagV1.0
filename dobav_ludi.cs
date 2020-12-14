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
    public partial class dobav_ludi : Form
    {
        public dobav_ludi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();

            try
            {
                conn.Open();
                string sql = "call insert_ludi ('"+textBox1.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Новый пользователь добавлен!");
                this.Hide();
                                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Ошибка, возможно такой человек уже существует ¯|_(ツ)_|¯");
            }
        }

        private void dobav_ludi_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
    }
}
