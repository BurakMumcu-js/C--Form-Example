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
    public partial class sil : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public sil()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadOgrenciler();

        }
        private void InitializeDatabaseConnection()
        {
            server = "localhost";
            database = "c#odev"; 
            uid = "root";
            password = "burak123"; 

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }
        private void LoadOgrenciler()
        {
            string query = "SELECT ogr_no, ogr_ad, ogr_soyad FROM ogrenci_islemleri";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçili öğrenciyi silmek istediğinizden emin misiniz?", "Öğrenci Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    connection.Open();

                    int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    string selectedOgrNo = dataGridView1.Rows[selectedRowIndex].Cells["ogr_no"].Value.ToString();

                    string deleteQuery = $"DELETE FROM ogrenci_islemleri WHERE ogr_no = '{selectedOgrNo}'";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Öğrenci başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadOgrenciler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
