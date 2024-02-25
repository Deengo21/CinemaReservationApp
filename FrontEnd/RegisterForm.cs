using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using BackEnd;
using DataEngine;
using Server;

namespace FrontEnd
{
    public partial class RegisterForm : Form
    {
        CinemaContext cinemaContext;
        private Customer _customer;
       
        public RegisterForm()
        {
            InitializeComponent();
            _customer = new Customer(cinemaContext);
            RegisterButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string name = rLoginBox.Text;
            string email = rMailBox.Text;
            string password = rPassBox.Text;
            string confirmPassword = rPass2Box.Text;

            try
            {
                if (password != confirmPassword)
                {
                    MessageBox.Show("Podane hasła nie zgadzają się.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _customer.Register(name, email, password);
                MessageBox.Show("Rejestracja przebiegła pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd rejestracji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rLoginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    } 
}
