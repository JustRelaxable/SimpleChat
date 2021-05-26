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
using System.Net.Sockets;

namespace SimpleChatClientSideCode
{
    public partial class MainPage : Form
    {
        Form loginPage;
        List<string> lines = new List<string>();
        Dictionary<string, List<Net_OnSendMessage>> messagesDic = new Dictionary<string, List<Net_OnSendMessage>>();
        public MainPage(Form loginPage)
        {
            this.loginPage = loginPage;
            EventManager.GetOnlineEmployees += GetOnlineEmployees;
            EventManager.SendMessage += SendMessage;
            InitializeComponent();
            RefreshButton_Click(this, EventArgs.Empty);
        }

        private void SendMessage(object sender, Net_OnSendMessage e)
        {
            /*
            lines.Add($"{e.From}:");
            lines.Add($"{e.Message}");
            MessagesTextBox.Lines = lines.ToArray();
            */
            if(e.From != EmployeeCreditentals.Email)
            {
                if (!e.IsServerMessage)
                {
                    List<Net_OnSendMessage> messagesList = new List<Net_OnSendMessage>();
                    if (messagesDic.TryGetValue(e.From, out messagesList))
                    {
                        messagesDic[e.From].Add(e);
                    }
                    else
                    {
                        messagesDic.Add(e.From, messagesList);
                        messagesDic[e.From] = new List<Net_OnSendMessage>();
                        messagesDic[e.From].Add(e);
                    }

                    if ((string)OnlineEmployeeListBox.SelectedItem == e.From)
                    {
                        richTextBox.Text += $"{e.From}:{e.Message}";
                        richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), e.From.Length);
                        richTextBox.SelectionColor = Color.Red;
                        richTextBox.Text += "\n";
                    }
                }
                else
                {
                    List<Net_OnSendMessage> messagesList = new List<Net_OnSendMessage>();
                    if (messagesDic.TryGetValue("Active Users", out messagesList))
                    {
                        messagesDic["Active Users"].Add(e);
                    }
                    else
                    {
                        messagesDic.Add("Active Users", messagesList);
                        messagesDic["Active Users"] = new List<Net_OnSendMessage>();
                        messagesDic["Active Users"].Add(e);
                    }

                    if ((string)OnlineEmployeeListBox.SelectedItem == "Active Users")
                    {
                        richTextBox.Text += $"{e.From}:{e.Message}";
                        richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), e.From.Length);
                        richTextBox.SelectionColor = Color.Red;
                        richTextBox.Text += "\n";
                    }
                }

            }
            else
            {
                if (!e.IsServerMessage)
                {
                    List<Net_OnSendMessage> messagesList = new List<Net_OnSendMessage>();
                    if (messagesDic.TryGetValue(e.To, out messagesList))
                    {
                        messagesDic[e.To].Add(e);
                    }
                    else
                    {
                        messagesDic.Add(e.To, messagesList);
                        messagesDic[e.To] = new List<Net_OnSendMessage>();
                        messagesDic[e.To].Add(e);
                    }


                    if ((string)OnlineEmployeeListBox.SelectedItem == e.To)
                    {
                        richTextBox.Text += $"{e.From}:{e.Message}";
                        richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), e.From.Length);
                        richTextBox.SelectionColor = Color.Red;
                        richTextBox.Text += "\n";
                    }
                }
                else
                {
                    List<Net_OnSendMessage> messagesList = new List<Net_OnSendMessage>();
                    if (messagesDic.TryGetValue("Active Users", out messagesList))
                    {
                        messagesDic["Active Users"].Add(e);
                    }
                    else
                    {
                        messagesDic.Add("Active Users", messagesList);
                        messagesDic["Active Users"] = new List<Net_OnSendMessage>();
                        messagesDic["Active Users"].Add(e);
                    }


                    if ((string)OnlineEmployeeListBox.SelectedItem == "Active Users")
                    {
                        richTextBox.Text += $"{e.From}:{e.Message}";
                        richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), e.From.Length);
                        richTextBox.SelectionColor = Color.Red;
                        richTextBox.Text += "\n";
                    }
                }
            }
            /*
            richTextBox.Text += $"{e.From}:{e.Message}";
            richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), e.From.Length);
            richTextBox.SelectionColor = Color.Red;
            richTextBox.Text += "\n";
            */
        }

        private void GetOnlineEmployees(object sender, Net_OnGetOnlineEmployees e)
        {
            OnlineEmployeeListBox.Items.Clear();
            for (int i = 0; i < e.EmployeeMails.Count; i++)
            {
                if(e.EmployeeMails[i] != EmployeeCreditentals.Email)
                {
                    OnlineEmployeeListBox.Items.Add(e.EmployeeMails[i]);
                }
            }
            OnlineEmployeeListBox.Items.Add("Active Users");
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Net_GetOnlineEmployees getOnlineEmployees = new Net_GetOnlineEmployees(EmployeeCreditentals.Token);
            SocketManager.ClientSocket.SendFromManager(getOnlineEmployees);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if(OnlineEmployeeListBox.SelectedItem != null && (string)OnlineEmployeeListBox.SelectedItem != EmployeeCreditentals.Email && MessageField.Text.Trim() != "")
            {
                if((string)OnlineEmployeeListBox.SelectedItem == "Active Users")
                {
                    Net_SendMessage sendMessage = new Net_SendMessage(MessageField.Text.Trim(), (string)OnlineEmployeeListBox.SelectedItem, EmployeeCreditentals.Token, true);
                    SocketManager.ClientSocket.SendFromManager(sendMessage);
                    MessageField.Clear();
                }
                else
                {
                    Net_SendMessage sendMessage = new Net_SendMessage(MessageField.Text.Trim(), (string)OnlineEmployeeListBox.SelectedItem,EmployeeCreditentals.Token,false);
                    SocketManager.ClientSocket.SendFromManager(sendMessage);
                    MessageField.Clear();
                }

            }
            else
            {
                MessageBox.Show("Can't send");
            }
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginPage.Show();
        }

        private void OnlineEmployeeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Net_OnSendMessage> messagesList;
            if(OnlineEmployeeListBox.SelectedItem != null && messagesDic.TryGetValue((string)OnlineEmployeeListBox.SelectedItem,out messagesList))
            {
                richTextBox.Clear();
                foreach (var item in messagesList)
                {
                    richTextBox.Text += $"{item.From}:{item.Message}";
                    richTextBox.Select(richTextBox.GetFirstCharIndexOfCurrentLine(), item.From.Length);
                    richTextBox.SelectionColor = Color.Red;
                    richTextBox.Text += "\n";
                }
            }
            else
            {
                richTextBox.Clear();
            }
        }

        private void MessageField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendButton_Click(sender, e);
            }
        }
    }
}
