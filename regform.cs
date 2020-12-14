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
    public partial class regform : Form
    {
        public regform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                 
                
            MySqlConnection conn = DBConn.GetDBConnection();

            try
            {
                conn.Open();
                string sql = "call `insert_ludi` ('Пользователь','"+textBox1.Text+"','"+dateTimePicker1.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox7.Text+"','"+textBox6.Text+"')";              
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                
                MessageBox.Show("Регистрация успешна!");
                conn.Close();
                Form bkc = new Form1();
                bkc.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void regform_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
    }
}
