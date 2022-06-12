using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {comboBoxDatabases.Text}.{comboBoxTables.Text}", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGrid.DataSource = table;
                connection.Close();
            }
            catch (MySqlException exception)
            {
                connection.Close();
                MessageBox.Show(exception.Message);
            }
        }

        int rowCount;
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCount = dataGrid.Rows.Count - 1;
        }

        private string GetValue(DataGridViewCell cell)
        {
            var type = cell.ValueType.Name;

            switch (type)
            {
                default:
                    {
                        MessageBox.Show("Unsupported value type!");
                    }
                    break;

                case "String":
                    {
                        return $"'{dataGrid.CurrentCell.Value}'";
                    }

                case "Single":
                case "Int32":
                    {
                        return dataGrid.CurrentCell.Value.ToString().Replace(",", ".");
                    }
            }
            return null;
        }

        private void DataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                connection.Open();
                var databaseName = comboBoxDatabases.Text;
                var tableName = comboBoxTables.Text;
                var columnName = dataGrid.Columns[dataGrid.CurrentCell.ColumnIndex].Name;
                var newValue = GetValue(dataGrid.CurrentCell);

                if (dataGrid.CurrentCell.RowIndex != rowCount)
                {
                    MySqlCommand command = new MySqlCommand($"UPDATE {databaseName}.{tableName} SET {columnName} = {newValue} WHERE {dataGrid.Columns[0].Name} = {dataGrid[0, dataGrid.CurrentCell.RowIndex].Value}", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                else
                {
                    MySqlCommand command = new MySqlCommand($"INSERT INTO {databaseName}.{tableName} ({columnName}) VALUES ({newValue})", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                connection.Close();
            }
            catch (MySqlException exception)
            {
                connection.Close();
                MessageBox.Show(exception.Message);
            }
        }

        MySqlConnection connection;
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder connectionString = new MySqlConnectionStringBuilder
            {
                Server = txtBoxServer.Text,
                UserID = txtBoxUsername.Text,
                Password = txtBoxPassword.Text
            };
            connection = new MySqlConnection(connectionString.ConnectionString);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SHOW DATABASES", connection);
                MySqlDataReader reader = command.ExecuteReader();
                comboBoxDatabases.Items.Clear();

                while (reader.Read())
                {
                    comboBoxDatabases.Items.Add(reader[0]);
                }
                connection.Close();
            }
            catch (MySqlException exception)
            {
                connection.Close();
                MessageBox.Show(exception.Message);
            }
        }

        private void ComboBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"SHOW TABLES FROM {comboBoxDatabases.Text}", connection);
                MySqlDataReader reader = command.ExecuteReader();
                comboBoxTables.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTables.Items.Add(reader[0]);
                }
                connection.Close();
            }
            catch (MySqlException exception)
            {
                connection.Close();
                MessageBox.Show(exception.Message);
            }
        }

        private void DataGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"DELETE FROM {comboBoxDatabases.Text}.{comboBoxTables.Text} WHERE {dataGrid.Columns[0].Name} = {dataGrid[0, dataGrid.CurrentCell.RowIndex].Value}", connection);
                MySqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            catch (MySqlException exception)
            {
                connection.Close();
                MessageBox.Show(exception.Message);
            }
        }
    }
}