using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleChatSharedCode;
using Newtonsoft.Json;


namespace SimpleChatClientSideCode
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            EventManager.EmployeeLogin += EmployeeLogin;
            InitializeComponent();
        }

        private void EmployeeLogin(object sender, Net_OnEmployeeLogin e)
        {
            switch (e.Status)
            {
                case Status.SuccessfulLogin:
                    EmployeeCreditentals.Token = e.Token;
                    EmployeeCreditentals.Email = EmailTextBox.Text;//Should be changed
                    MainPage mainPage = new MainPage(this);
                    mainPage.Show();
                    this.Hide();
                    break;
                case Status.WrongEmailOrPassword:
                    MessageBox.Show("Wrong Email or Password Given");
                    break;
                case Status.AlreadyLoggedIn:
                    MessageBox.Show("Employee Already Logged In!");
                    break;
                default:
                    break;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(EmailTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Net_EmployeeLogin loginData = new Net_EmployeeLogin(EmailTextBox.Text,Utilities.ComputeSha256Hash(PasswordTextBox.Text));//Calculate hash
                SocketManager.ClientSocket.SendFromManager(loginData);
            }
            else
            {
                MessageBox.Show("Email and password text boxes should be filled!", "Info", MessageBoxButtons.OK);
            }
        }

        private void RegisterPageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterPage(this).Show();
        }
    }
}
