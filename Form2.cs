using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace modul6
{
    public partial class Form2 : Form
    {
        public Form2(string username)
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=127.0.0.1;port=3306;username=root;password=;database=percobaan2-rpl";
                string Query = "INSERT INTO mahasiswa(nim, nama, kelas, umur, semester) VALUES(@nim, @nama, @kelas, @umur, @semester);";
                using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
                using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
                {
                    MyCommand2.Parameters.AddWithValue("@nim", txtNim.Text);
                    MyCommand2.Parameters.AddWithValue("@nama", txtNama.Text);
                    MyCommand2.Parameters.AddWithValue("@kelas", txtKelas.Text);
                    MyCommand2.Parameters.AddWithValue("@umur", txtUmur.Text);
                    MyCommand2.Parameters.AddWithValue("@semester", txtSemester.Text);
                    MyConn2.Open();
                    MyCommand2.ExecuteNonQuery();
                    MessageBox.Show("Data Saved");
                }
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=127.0.0.1;port=3306;username=root;password=;database=percobaan2-rpl";
                string Query = "UPDATE mahasiswa SET nama=@nama, kelas=@kelas, umur=@umur, semester=@semester WHERE nim=@nim;";
                using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
                using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
                {
                    MyCommand2.Parameters.AddWithValue("@nim", txtNim.Text);
                    MyCommand2.Parameters.AddWithValue("@nama", txtNama.Text);
                    MyCommand2.Parameters.AddWithValue("@kelas", txtKelas.Text);
                    MyCommand2.Parameters.AddWithValue("@umur", txtUmur.Text);
                    MyCommand2.Parameters.AddWithValue("@semester", txtSemester.Text);
                    MyConn2.Open();
                    MyCommand2.ExecuteNonQuery();
                    MessageBox.Show("Data Updated");
                }
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=127.0.0.1;port=3306;username=root;password=;database=percobaan2-rpl";
                string Query = "DELETE FROM mahasiswa WHERE nim=@nim;";
                using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
                using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
                {
                    MyCommand2.Parameters.AddWithValue("@nim", txtNim.Text);
                    MyConn2.Open();
                    MyCommand2.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted");
                }
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "server=127.0.0.1;port=3306;username=root;password=;database=percobaan2-rpl";
                string Query = "SELECT * FROM mahasiswa;";
                using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
                using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
                using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(MyCommand2))
                {
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtNim.Text = row.Cells["nim"].Value.ToString();
                txtNama.Text = row.Cells["nama"].Value.ToString();
                txtKelas.Text = row.Cells["kelas"].Value.ToString();
                txtUmur.Text = row.Cells["umur"].Value.ToString();
                txtSemester.Text = row.Cells["semester"].Value.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            txtNim.Text = "";
            txtNama.Text = "";
            txtKelas.Text = "";
            txtUmur.Text = "";
            txtSemester.Text = "";
        }
    }
}
