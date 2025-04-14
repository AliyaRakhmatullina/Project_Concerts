namespace Project_Concerts
{
    partial class Watch
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
            this.comboBoxLoadEvents = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.buttonShowEvent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxLoadEvents
            // 
            this.comboBoxLoadEvents.FormattingEnabled = true;
            this.comboBoxLoadEvents.Location = new System.Drawing.Point(12, 25);
            this.comboBoxLoadEvents.Name = "comboBoxLoadEvents";
            this.comboBoxLoadEvents.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLoadEvents.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите событие, которое хотите посмотреть";
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            this.dataGridViewEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.RowHeadersVisible = false;
            this.dataGridViewEvents.Size = new System.Drawing.Size(734, 99);
            this.dataGridViewEvents.TabIndex = 2;
            // 
            // buttonShowEvent
            // 
            this.buttonShowEvent.Location = new System.Drawing.Point(139, 24);
            this.buttonShowEvent.Name = "buttonShowEvent";
            this.buttonShowEvent.Size = new System.Drawing.Size(122, 22);
            this.buttonShowEvent.TabIndex = 3;
            this.buttonShowEvent.Text = "Просмотреть";
            this.buttonShowEvent.UseVisualStyleBackColor = true;
            this.buttonShowEvent.Click += new System.EventHandler(this.buttonShowEvent_Click);
            // 
            // Watch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(758, 164);
            this.Controls.Add(this.buttonShowEvent);
            this.Controls.Add(this.dataGridViewEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLoadEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Watch";
            this.Text = "События";
            this.Load += new System.EventHandler(this.Watch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLoadEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.Button buttonShowEvent;
    }
}