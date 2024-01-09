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
    public partial class düzenle : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "c#odev";
        private string uid = "root";
        private string password = "burak123";

        public düzenle()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadOgrenciler();
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            connection = new MySqlConnection(connectionString);
        }
        private void LoadOgrenciler()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();


                string query = "SELECT ogr_no, ogr_ad, ogr_soyad FROM ogrenci_islemleri";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgv.DataSource = dt;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
   
                string selectedOgrNo = dgv.SelectedRows[0].Cells["ogr_no"].Value.ToString();

      
                düzenle2 fr2 = new düzenle2(selectedOgrNo);
                fr2.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
