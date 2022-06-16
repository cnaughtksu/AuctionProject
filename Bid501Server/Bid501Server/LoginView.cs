using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501Server
{
    public delegate bool LoginInputHandler(string username, string password);
    public partial class LoginView : Form
    {
        private string name;
        private string password;
        public LoginInputHandler login;
        public LoginView(LoginInputHandler l)
        {
            login = l;
            InitializeComponent();
        }
        public void UpdateView(LoginStatus status)
        {
            if (status == LoginStatus.FailedLogin)
            {
                UxDisplayLabel.Text = status.ToString();
            }
            else
            {
                MessageBox.Show("Login Succesful");
                this.Hide();
            }
        }
        private void Login_Button_Click(object sender, EventArgs e)
        {
            bool temp = login(UserName_TextBox.Text, Password_TextBox.Text);

            if (temp)
            {
                UpdateView(LoginStatus.SuccessfulLogin);
            }
            else
            {
                UpdateView(LoginStatus.FailedLogin);
            }
        }
    }
}
