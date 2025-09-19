namespace FactorioComputerSimulator.GUI.Simulation
{
    partial class RegistersInformationShow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ComboBoxFormat = new System.Windows.Forms.ToolStripComboBox();
            this.RegostersGrid = new System.Windows.Forms.DataGridView();
            this.Register = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegostersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComboBoxFormat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(206, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ComboBoxFormat
            // 
            this.ComboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFormat.Items.AddRange(new object[] {
            "Hex",
            "Bin"});
            this.ComboBoxFormat.Name = "ComboBoxFormat";
            this.ComboBoxFormat.Size = new System.Drawing.Size(180, 23);
            this.ComboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormat_SelectedIndexChanged);
            // 
            // RegostersGrid
            // 
            this.RegostersGrid.AllowUserToAddRows = false;
            this.RegostersGrid.AllowUserToResizeRows = false;
            this.RegostersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RegostersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegostersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Register,
            this.Value});
            this.RegostersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegostersGrid.Location = new System.Drawing.Point(0, 33);
            this.RegostersGrid.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.RegostersGrid.Name = "RegostersGrid";
            this.RegostersGrid.ReadOnly = true;
            this.RegostersGrid.RowHeadersVisible = false;
            this.RegostersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RegostersGrid.Size = new System.Drawing.Size(206, 231);
            this.RegostersGrid.TabIndex = 3;
            // 
            // Register
            // 
            this.Register.HeaderText = "Register";
            this.Register.Name = "Register";
            this.Register.ReadOnly = true;
            this.Register.Width = 94;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 75;
            // 
            // RegistersInformationShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(206, 264);
            this.Controls.Add(this.RegostersGrid);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistersInformationShow";
            this.Text = "RegistersInformationShow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegostersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox ComboBoxFormat;
        private System.Windows.Forms.DataGridView RegostersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Register;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}