namespace LF10Demo
{
    partial class AssemblyForm
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyForm));
          this.assemblyGridView = new System.Windows.Forms.DataGridView();
          ((System.ComponentModel.ISupportInitialize)(this.assemblyGridView)).BeginInit();
          this.SuspendLayout();
          // 
          // assemblyGridView
          // 
          this.assemblyGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.assemblyGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
          this.assemblyGridView.BackgroundColor = System.Drawing.Color.White;
          this.assemblyGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.assemblyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.assemblyGridView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.assemblyGridView.Location = new System.Drawing.Point(0, 0);
          this.assemblyGridView.Name = "assemblyGridView";
          this.assemblyGridView.Size = new System.Drawing.Size(528, 344);
          this.assemblyGridView.TabIndex = 0;
          // 
          // AssemblyForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(528, 344);
          this.Controls.Add(this.assemblyGridView);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "AssemblyForm";
          this.Text = "Assembly Info";
          this.Load += new System.EventHandler(this.AssemblyForm_Load);
          ((System.ComponentModel.ISupportInitialize)(this.assemblyGridView)).EndInit();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView assemblyGridView;

    }
}