using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=mytestdb;");
        private void RefreshDataGrid()
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT ItemName, Price FROM mytesttable", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGrid.DataSource = table;
                connection.Close();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public FormMain()
        {
            InitializeComponent();
            RefreshDataGrid();
        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        int rowCount;
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCount = dataGrid.Rows.Count - 1;
        }
        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGrid.CurrentCell.RowIndex == rowCount)
                {
                    connection.Open();
                    switch (dataGrid.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            {
                                MySqlCommand command = new MySqlCommand($"INSERT INTO mytesttable (ItemName) VALUES ('{dataGrid.CurrentCell.Value}')", connection);
                                MySqlDataReader reader = command.ExecuteReader();
                            }
                            break;
                        case 1:
                            {
                            }
                            break;
                    }
                    connection.Close();
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}