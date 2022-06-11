using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=test-db;");
        public FormMain()
        {
            InitializeComponent();
            switch (connection.State)
            {
                case ConnectionState.Closed:
                    {
                        btnCon.Text = "Open connection";
                    }
                    break;
                case ConnectionState.Open:
                    {
                        btnCon.Text = "Close connection";
                    }
                    break;
            }
        }
        private void btnCon_Click(object sender, EventArgs e)
        {
            try
            {
                switch (connection.State)
                {
                    case ConnectionState.Closed:
                        {
                            connection.Open();
                            btnCon.Text = "Close connection";
                        }
                        break;
                    case ConnectionState.Open:
                        {
                            connection.Close();
                            btnCon.Text = "Open connection";
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
