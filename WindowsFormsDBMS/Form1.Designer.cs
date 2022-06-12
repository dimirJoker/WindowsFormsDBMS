namespace WindowsFormsDBMS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRead = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.txtBoxServer = new System.Windows.Forms.TextBox();
            this.txtBoxTable = new System.Windows.Forms.TextBox();
            this.txtBoxDatabase = new System.Windows.Forms.TextBox();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboBoxDatabases = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(673, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(115, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "READ";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 41);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(776, 397);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
            this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellValueChanged);
            // 
            // txtBoxServer
            // 
            this.txtBoxServer.Location = new System.Drawing.Point(12, 14);
            this.txtBoxServer.Name = "txtBoxServer";
            this.txtBoxServer.Size = new System.Drawing.Size(100, 20);
            this.txtBoxServer.TabIndex = 2;
            this.txtBoxServer.Text = "localhost";
            // 
            // txtBoxTable
            // 
            this.txtBoxTable.Location = new System.Drawing.Point(567, 14);
            this.txtBoxTable.Name = "txtBoxTable";
            this.txtBoxTable.Size = new System.Drawing.Size(100, 20);
            this.txtBoxTable.TabIndex = 3;
            this.txtBoxTable.Text = "mytesttable";
            // 
            // txtBoxDatabase
            // 
            this.txtBoxDatabase.Location = new System.Drawing.Point(461, 14);
            this.txtBoxDatabase.Name = "txtBoxDatabase";
            this.txtBoxDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDatabase.TabIndex = 4;
            this.txtBoxDatabase.Text = "mytestdb";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(118, 14);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUsername.TabIndex = 5;
            this.txtBoxUsername.Text = "root";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(224, 14);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassword.TabIndex = 6;
            this.txtBoxPassword.Text = "root";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(330, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboBoxDatabases
            // 
            this.comboBoxDatabases.FormattingEnabled = true;
            this.comboBoxDatabases.Location = new System.Drawing.Point(583, 387);
            this.comboBoxDatabases.Name = "comboBoxDatabases";
            this.comboBoxDatabases.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabases.TabIndex = 8;
            this.comboBoxDatabases.Text = "Databases";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxDatabases);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUsername);
            this.Controls.Add(this.txtBoxDatabase);
            this.Controls.Add(this.txtBoxTable);
            this.Controls.Add(this.txtBoxServer);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnRead);
            this.Name = "FormMain";
            this.Text = "My DBMS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox txtBoxServer;
        private System.Windows.Forms.TextBox txtBoxTable;
        private System.Windows.Forms.TextBox txtBoxDatabase;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboBoxDatabases;
    }
}

