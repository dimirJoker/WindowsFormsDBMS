using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=root;Database=mytestdb;");
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM mytesttable", connection);
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
        private void btnConnection_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var selectedCell = dataGrid.GetCellCount(DataGridViewElementStates.Selected);
            StringBuilder stringBuilder = new StringBuilder();
            var i = 0;
            for (; i < selectedCell; i++)
            {
                stringBuilder.Append("Row: ");
                stringBuilder.Append(dataGrid.SelectedCells[i].RowIndex.ToString());
                stringBuilder.Append(", column: ");
                stringBuilder.Append(dataGrid.SelectedCells[i].ColumnIndex.ToString());
            }
            MessageBox.Show(stringBuilder.ToString(), "Selected cell");
        }
    }
}