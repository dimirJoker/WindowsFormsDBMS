using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=root;database=mytestdb");
        public FormMain()
        {
            InitializeComponent();
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            SetDataGrid();
        }
        int rowCount;
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowCount = dataGrid.Rows.Count - 1;
        }
        private string GetValueByType(DataGridViewCell cell)
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
                    {
                        return dataGrid.CurrentCell.Value.ToString().Replace(",", ".");
                    }
            }
            return null;
        }
        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dataGrid.CurrentCell.ColumnIndex)
                {
                    default:
                        {
                            connection.Open();
                            var column = dataGrid.Columns[dataGrid.CurrentCell.ColumnIndex].Name;
                            var value = GetValueByType(dataGrid.CurrentCell);
                            if (dataGrid.CurrentCell.RowIndex != rowCount)
                            {
                                UPDATE(column, value);
                            }
                            else
                            {
                                INSERT(column, value);
                            }
                            connection.Close();
                        }
                        break;
                    case 0:
                        {
                            MessageBox.Show("It's forbidden to change the ID!");
                            SetDataGrid();
                        }
                        break;
                }
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void SetDataGrid()
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {txtBoxTable.Text}", connection); // "SELECT * FROM mytesttable"
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
        private void INSERT(string column, string value)
        {
            MySqlCommand command = new MySqlCommand($"INSERT INTO mytesttable ({column}) VALUES ({value})", connection);
            MySqlDataReader reader = command.ExecuteReader();
        }
        private void UPDATE(string column, string value)
        {
            MySqlCommand command = new MySqlCommand($"UPDATE mytesttable SET {column} = {value} WHERE Id = {dataGrid[0, dataGrid.CurrentCell.RowIndex].Value}", connection);
            MySqlDataReader reader = command.ExecuteReader();
        }
    }
}