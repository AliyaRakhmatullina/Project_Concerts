namespace Project_Concerts
{
    partial class Delete
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDeleteEvent = new System.Windows.Forms.ComboBox();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите событие";
            // 
            // comboBoxDeleteEvent
            // 
            this.comboBoxDeleteEvent.FormattingEnabled = true;
            this.comboBoxDeleteEvent.Location = new System.Drawing.Point(16, 30);
            this.comboBoxDeleteEvent.Name = "comboBoxDeleteEvent";
            this.comboBoxDeleteEvent.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDeleteEvent.TabIndex = 1;
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.Location = new System.Drawing.Point(144, 30);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(116, 23);
            this.buttonDeleteEvent.TabIndex = 2;
            this.buttonDeleteEvent.Text = "Удалить событие";
            this.buttonDeleteEvent.UseVisualStyleBackColor = true;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 152);
            this.Controls.Add(this.buttonDeleteEvent);
            this.Controls.Add(this.comboBoxDeleteEvent);
            this.Controls.Add(this.label1);
            this.Name = "Delete";
            this.Text = "Удаление события";
            this.Load += new System.EventHandler(this.DeleteEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeleteEvent;
        private System.Windows.Forms.Button buttonDeleteEvent;
    }
}