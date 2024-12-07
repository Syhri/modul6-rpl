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

namespace modul6
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            SetPlaceholder();
        }

        private void SetPlaceholder()
        {
            SetPlaceholder(txtFirstname, "First Name");
            SetPlaceholder(txtLastname, "Last Name");
            SetPlaceholder(txtEmail, "Email Address");
            SetPlaceholder(textUsername, "Username");
            SetPlaceholder(textPassword, "Password");
            SetPlaceholder(txtConfirmpassword, "Confirm Password");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Enter += (sender, e) => RemovePlaceholder(textBox, placeholder);
            textBox.Leave += (sender, e) => AddPlaceholder(textBox, placeholder);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (textBox == textPassword || textBox == txtConfirmpassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void AddPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == textPassword || textBox == txtConfirmpassword)
                {
                    textBox.UseSystemPasswordChar = false;
                }
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            string email = txtEmail.Text;
            string username = textUsername.Text;
            string password = textPassword.Text;
            string confirmPassword = txtConfirmpassword.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string MyConnection2 = "server=127.0.0.1;port=3306;username=root;password=;database=percobaan2-rpl";
                string Query = "INSERT INTO users (first_name, last_name, email, username, password) VALUES (@firstName, @lastName, @Email, @Username, @Password);";
                using (MySqlConnection MyConn2 = new MySqlConnection(MyConnection2))
                using (MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2))
                {
                    MyCommand2.Parameters.AddWithValue("@firstName", firstName);
                    MyCommand2.Parameters.AddWithValue("@lastName", lastName);
                    MyCommand2.Parameters.AddWithValue("@Email", email);
                    MyCommand2.Parameters.AddWithValue("@Username", username);
                    MyCommand2.Parameters.AddWithValue("@Password", password);
                    MyConn2.Open();
                    MyCommand2.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");

                    // Redirect to the login form after successful registration
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
