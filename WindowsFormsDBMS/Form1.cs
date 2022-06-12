using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True"); // TO DO VARS

        public FormMain()
        {
            InitializeComponent();
        }

        private void SetDataGrid()
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {comboBoxDatabases.Text}.{comboBoxTables.Text}", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGrid.DataSource = table;
                connection.Close();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            SetDataGrid();
        }

        int rowCount;
        string prevValue;
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCount = dataGrid.Rows.Count - 1;
            prevValue = GetValue(dataGrid.CurrentCell);
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
                var columnName = dataGrid.Columns[dataGrid.CurrentCell.ColumnIndex].Name;
                var newValue = GetValue(dataGrid.CurrentCell);

                if (dataGrid.CurrentCell.RowIndex != rowCount)
                {
                    SqlCommand command = new SqlCommand($"UPDATE {comboBoxDatabases.Text}.{comboBoxTables.Text} SET {columnName} = {newValue} WHERE {columnName} = {prevValue}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                }
                else
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO {comboBoxDatabases.Text}.{comboBoxTables.Text} ({columnName}) VALUES ({newValue})", connection);
                    SqlDataReader reader = command.ExecuteReader();
                }
                connection.Close();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SHOW DATABASES", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBoxDatabases.Items.Add(reader[0]);
            }
            connection.Close();
        }

        private void ComboBoxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"SHOW TABLES FROM {comboBoxDatabases.Text}", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBoxTables.Items.Add(reader[0]);
            }
            connection.Close();
        }
    }
}