using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using Renci.SshNet;


namespace Mag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DBConn.GetDBConnection();

            try
            {
                conn.Open();
                string sql = "select `ludi`.`FIO` from `ludi` where `ludi`.`login` = '" + textBox1.Text + "' and `ludi`.`pass` = '" + textBox2.Text + "';";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    if (!(reader["FIO"].GetType()==null))
                     {
                        MessageBox.Show(reader["FIO"].ToString());
                        this.Hide();
                        Form nwfrm = new Main_form();
                        nwfrm.Show();
                        nwfrm = new post();
                        nwfrm.Show();
                        nwfrm = new Tovary();
                        nwfrm.Show();
                        nwfrm = new zhurnal();
                        nwfrm.Show();


                     }
                }
                catch (Exception)
                {

                    MessageBox.Show("Неверная пара логин/пароль");
                }
               



                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }



        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new regform();
            f.Show();
            this.Hide();

        }
    }
}
