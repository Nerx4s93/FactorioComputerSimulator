namespace FactorioComputerSimulator.GUI
{
    partial class SimulationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonStart = new System.Windows.Forms.ToolStripButton();
            this.ButtonPause = new System.Windows.Forms.ToolStripButton();
            this.TextBoxSpeed = new System.Windows.Forms.ToolStripTextBox();
            this.buttonRomShow = new System.Windows.Forms.Button();
            this.buttonRamShow = new System.Windows.Forms.Button();
            this.buttonRegistersShow = new System.Windows.Forms.Button();
            this.ButtonStep = new System.Windows.Forms.Button();
            this.LabelPCInfo = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonStart,
            this.ButtonPause,
            this.TextBoxSpeed});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(502, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonStart
            // 
            this.ButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStart.Image")));
            this.ButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(23, 22);
            this.ButtonStart.Text = "toolStripButton4";
            // 
            // ButtonPause
            // 
            this.ButtonPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPause.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPause.Image")));
            this.ButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(23, 22);
            this.ButtonPause.Text = "toolStripButton3";
            // 
            // TextBoxSpeed
            // 
            this.TextBoxSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxSpeed.Name = "TextBoxSpeed";
            this.TextBoxSpeed.Size = new System.Drawing.Size(50, 25);
            this.TextBoxSpeed.Text = "1000";
            // 
            // buttonRomShow
            // 
            this.buttonRomShow.Location = new System.Drawing.Point(12, 28);
            this.buttonRomShow.Name = "buttonRomShow";
            this.buttonRomShow.Size = new System.Drawing.Size(82, 23);
            this.buttonRomShow.TabIndex = 1;
            this.buttonRomShow.Text = "ROM";
            this.buttonRomShow.UseVisualStyleBackColor = true;
            this.buttonRomShow.Click += new System.EventHandler(this.buttonRomShow_Click);
            // 
            // buttonRamShow
            // 
            this.buttonRamShow.Location = new System.Drawing.Point(100, 28);
            this.buttonRamShow.Name = "buttonRamShow";
            this.buttonRamShow.Size = new System.Drawing.Size(82, 23);
            this.buttonRamShow.TabIndex = 2;
            this.buttonRamShow.Text = "RAM";
            this.buttonRamShow.UseVisualStyleBackColor = true;
            this.buttonRamShow.Click += new System.EventHandler(this.buttonRamShow_Click);
            // 
            // buttonRegistersShow
            // 
            this.buttonRegistersShow.Location = new System.Drawing.Point(188, 28);
            this.buttonRegistersShow.Name = "buttonRegistersShow";
            this.buttonRegistersShow.Size = new System.Drawing.Size(82, 23);
            this.buttonRegistersShow.TabIndex = 3;
            this.buttonRegistersShow.Text = "Registers";
            this.buttonRegistersShow.UseVisualStyleBackColor = true;
            this.buttonRegistersShow.Click += new System.EventHandler(this.buttonRegistersShow_Click);
            // 
            // ButtonStep
            // 
            this.ButtonStep.Location = new System.Drawing.Point(276, 28);
            this.ButtonStep.Name = "ButtonStep";
            this.ButtonStep.Size = new System.Drawing.Size(82, 23);
            this.ButtonStep.TabIndex = 4;
            this.ButtonStep.Text = "Step";
            this.ButtonStep.UseVisualStyleBackColor = true;
            this.ButtonStep.Click += new System.EventHandler(this.ButtonStep_Click);
            // 
            // LabelPCInfo
            // 
            this.LabelPCInfo.AutoSize = true;
            this.LabelPCInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPCInfo.ForeColor = System.Drawing.Color.White;
            this.LabelPCInfo.Location = new System.Drawing.Point(364, 28);
            this.LabelPCInfo.Name = "LabelPCInfo";
            this.LabelPCInfo.Size = new System.Drawing.Size(65, 25);
            this.LabelPCInfo.TabIndex = 5;
            this.LabelPCInfo.Text = "PC=0";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 15.75F);
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(12, 57);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(478, 381);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(502, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.LabelPCInfo);
            this.Controls.Add(this.ButtonStep);
            this.Controls.Add(this.buttonRegistersShow);
            this.Controls.Add(this.buttonRamShow);
            this.Controls.Add(this.buttonRomShow);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SimulationForm";
            this.Text = "Simulation";
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonStart;
        private System.Windows.Forms.ToolStripButton ButtonPause;
        private System.Windows.Forms.ToolStripTextBox TextBoxSpeed;
        private System.Windows.Forms.Button buttonRomShow;
        private System.Windows.Forms.Button buttonRamShow;
        private System.Windows.Forms.Button buttonRegistersShow;
        private System.Windows.Forms.Button ButtonStep;
        private System.Windows.Forms.Label LabelPCInfo;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}