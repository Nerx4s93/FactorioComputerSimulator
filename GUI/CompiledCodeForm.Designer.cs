namespace FactorioComputerSimulator.GUI
{
    partial class CompiledCodeForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lineNumbersBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lineNumbersBox)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.Location = new System.Drawing.Point(70, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(646, 530);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = " ";
            // 
            // lineNumbersBox
            // 
            this.lineNumbersBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lineNumbersBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineNumbersBox.Location = new System.Drawing.Point(0, 0);
            this.lineNumbersBox.Name = "lineNumbersBox";
            this.lineNumbersBox.Size = new System.Drawing.Size(70, 530);
            this.lineNumbersBox.TabIndex = 6;
            this.lineNumbersBox.TabStop = false;
            this.lineNumbersBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LineNumbersBox_Paint);
            // 
            // CompiledCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 530);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lineNumbersBox);
            this.Name = "CompiledCodeForm";
            this.Text = "CompoledCodeForm";
            ((System.ComponentModel.ISupportInitialize)(this.lineNumbersBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox lineNumbersBox;
    }
}