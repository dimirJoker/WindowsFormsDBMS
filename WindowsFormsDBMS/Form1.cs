﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDBMS
{
    public partial class FormMain : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=root"); // TO DO VARS

        public FormMain()
        {
            InitializeComponent();
        }

        private void SetDataGrid()
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {comboBoxDatabases.Text}.{txtBoxTable.Text}", connection);
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
                    MySqlCommand command = new MySqlCommand($"UPDATE {comboBoxDatabases.Text}.{txtBoxTable.Text} SET {columnName} = {newValue} WHERE {columnName} = {prevValue}", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                else
                {
                    MySqlCommand command = new MySqlCommand($"INSERT INTO {comboBoxDatabases.Text}.{txtBoxTable.Text} ({columnName}) VALUES ({newValue})", connection);
                    MySqlDataReader reader = command.ExecuteReader();
                }
                connection.Close();
            }
            catch (MySqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SHOW DATABASES",connection);
            MySqlDataReader reader=command.ExecuteReader();

            while (reader.Read())
            {
                comboBoxDatabases.Items.Add(reader[0]);
            }
            connection.Close();
        }
    }
}