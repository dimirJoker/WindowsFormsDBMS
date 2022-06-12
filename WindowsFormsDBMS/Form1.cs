using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=mytestdb;");
        public FormMain()
        {
            InitializeComponent();
            switch (connection.State)
            {
                case ConnectionState.Closed:
                    {
                        btnConnection.Text = "Open connection";
                    }
                    break;
                case ConnectionState.Open:
                    {
                        btnConnection.Text = "Close connection";
                    }
                    break;
            }
        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            try
            {
                switch (connection.State)
                {
                    case ConnectionState.Closed:
                        {
                            connection.Open();
                            btnConnection.Text = "Close connection";
                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM mytesttable", connection);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGrid.DataSource = dataTable;
                        }
                        break;
                    case ConnectionState.Open:
                        {
                            connection.Close();
                            btnConnection.Text = "Open connection";
                            dataGrid.DataSource = null;
                        }
                        break;
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}