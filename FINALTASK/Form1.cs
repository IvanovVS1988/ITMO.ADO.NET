using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTaskADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection connection = LoginForm.connection;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm openLoginForm = new LoginForm();
            openLoginForm.Owner = this;
            openLoginForm.Show();
        }
        private void подключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm openLoginForm = new LoginForm();
            openLoginForm.Owner = this;
            openLoginForm.Show();
        }

        private void отключитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Customers";
            OleDbDataReader reader = command.ExecuteReader();

            ListViewItem item = null;
            while (reader.Read())
            {
                item = new ListViewItem(new String[] { Convert.ToString(reader["CustomerID"]),
                Convert.ToString(reader["FirstName"]),
                Convert.ToString(reader["LastName"]),
                Convert.ToString(reader["Country"]),
                Convert.ToString(reader["City"])});
                customersListView.Items.Add(item);            
            }

            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            command1.CommandText = "SELECT * FROM Orders";
            OleDbDataReader reader1 = command1.ExecuteReader();

            ListViewItem item1 = null;
            while(reader1.Read())
            {
                item1 = new ListViewItem(new String[] { Convert.ToString(reader1["OrderID"]),
                Convert.ToString(reader1["CustomerID"]),
                Convert.ToString(reader1["Product"]),
                Convert.ToString(reader1["Number"]),
                Convert.ToString(reader1["Price"]),
                Convert.ToString(reader1["Discount"])});
                ordersListView.Items.Add(item1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OleDbTransaction OleTran = connection.BeginTransaction();
            OleDbCommand command = connection.CreateCommand();
            command.Transaction = OleTran;
            try
            {
                command.CommandText = $"INSERT INTO Customers (CustomerID) VALUES('{customerIDTextBox}')";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Customers (FirstName) VALUES ({firstNameTextBox})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Customers (LastName) VALUES ({lastNameTextBox})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Customers (Country) VALUES ({countryTextBox})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Customers (City) VALUES ({cityTextBox})";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbTransaction OleTran = connection.BeginTransaction();
            OleDbCommand command = connection.CreateCommand();
            command.Transaction = OleTran;
            try
            {
                command.CommandText = $"INSERT INTO Orders OrderID) VALUES('{textBox1}')";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Orders (CustomerID) VALUES ({textBox2})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Orders (Product) VALUES ({textBox3})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Orders (Number) VALUES ({textBox4})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Orders (Price) VALUES ({textBox5})";
                command.ExecuteNonQuery();
                command.CommandText = $"INSERT INTO Orders (Discount) VALUES ({textBox6})";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
