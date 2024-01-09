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

namespace App3
{
    public partial class ekleme : Form
    {
        public ekleme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "server=localhost;database=c#odev;uid=root;password=burak123";



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();


                string query = "INSERT INTO ogrenci_islemleri (ogr_ad, ogr_soyad, ogr_no) VALUES (@ad, @soyad, @no)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@ad", textad.Text);
                    cmd.Parameters.AddWithValue("@soyad", textsoyad.Text);
                    cmd.Parameters.AddWithValue("@no", textno.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
