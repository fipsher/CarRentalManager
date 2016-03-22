using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalManager.Repositories;
using CarRentalManager.Entities;
using CarRentalManager.Code;
using System.Configuration;


namespace CarRentalManager
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;

        public LoginForm()
        {
            _userRepository = new SqlUserRepository(ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString);

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            User user = _userRepository.GetUserByLogin(login, password);
            if (user == null)
            {
                this.DialogResult = DialogResult.No;
                MessageBox.Show(this, "Invalid user name or password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                CurrentUser.Initialize(user);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
