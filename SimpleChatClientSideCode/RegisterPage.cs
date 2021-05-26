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

namespace SimpleChatClientSideCode
{
    public partial class RegisterPage : Form
    {
        Form loginPage;
        public RegisterPage(Form _loginPage)
        {
            loginPage = _loginPage;
            EventManager.EmployeeRegister += EmployeeRegister;
            InitializeComponent();
        }

        private void EmployeeRegister(object sender, Net_OnEmployeeRegister e)
        {
            switch (e.Status)
            {
                case Status.Successful:
                    MessageBox.Show("Successful");
                    break;
                case Status.EmployeeAlreadyExist:
                    MessageBox.Show("Employee Already Exists");
                    break;
                case Status.IdentityNumberNotFound:
                    MessageBox.Show("Email not found!");
                    break;
                default:
                    break;
            }
            
        }

        private void RegisterPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginPage.Show();
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(PasswordTextBox.Text) && !string.IsNullOrEmpty(VerifyTextBox.Text) && !string.IsNullOrEmpty(EmailTextBox.Text))
            {
                if(PasswordTextBox.Text == VerifyTextBox.Text)
                {
                    //Send to server
                    Net_EmployeeRegister employeeRegister = new Net_EmployeeRegister(EmailTextBox.Text, Utilities.ComputeSha256Hash(VerifyTextBox.Text));
                    SocketManager.ClientSocket.SendFromManager(employeeRegister);
                    
                }
                else
                {
                    MessageBox.Show("Passwords should match!", "Info", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("All text boxes should be filled!", "Info", MessageBoxButtons.OK);
            }
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                RegisterButton_Click(sender, e);
            }
        }
    }
}
