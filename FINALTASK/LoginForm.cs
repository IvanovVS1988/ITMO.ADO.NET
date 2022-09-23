using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalTaskADO
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string Login;
        string Password;
        public static OleDbConnection connection = new OleDbConnection();

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    Login = loginTextBox.Text;
                    Password = passwordTextBox.Text;
                    connection.ConnectionString = $"Provider=SQLOLEDB.1;Persist Security Info=False;User ID={Login}; Password={Password};" +
                         @"Initial Catalog=FinalTask_Ado.net;Data Source=MSI\SQLEXPRESS";
                    connection.Open();
                    MessageBox.Show("Соединение установленно");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Соединение уже было установлено");
                    this.Close();
                }
            }
            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "SQL Error code " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
