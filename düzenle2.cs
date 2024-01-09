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
    public partial class düzenle2 : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "c#odev";
        private string uid = "root";
        private string password = "burak123";
        private string selectedOgrNo;
        public düzenle2(string ogrNo)
        {
            InitializeComponent();
            selectedOgrNo = ogrNo;
            InitializeDatabaseConnection();
            LoadSelectedOgrenci();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }
        private void LoadSelectedOgrenci()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

     
                string query = $"SELECT ogr_ad, ogr_soyad FROM ogrenci_islemleri WHERE ogr_no = '{selectedOgrNo}'";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        textboxad.Text = reader["ogr_ad"].ToString();
                        textboxsoyad.Text = reader["ogr_soyad"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string updateQuery = $"UPDATE ogrenci_islemleri SET ogr_ad = @ad, ogr_soyad = @soyad WHERE ogr_no = '{selectedOgrNo}'";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@ad", textboxad.Text);
                updateCmd.Parameters.AddWithValue("@soyad", textboxsoyad.Text);
                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}