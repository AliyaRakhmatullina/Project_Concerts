﻿namespace Project_Concerts
{
    partial class ChooseEvent
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
            this.comboBoxChooseEventEdit = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
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
            // comboBoxChooseEventEdit
            // 
            this.comboBoxChooseEventEdit.FormattingEnabled = true;
            this.comboBoxChooseEventEdit.Location = new System.Drawing.Point(16, 30);
            this.comboBoxChooseEventEdit.Name = "comboBoxChooseEventEdit";
            this.comboBoxChooseEventEdit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChooseEventEdit.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Перейти к редактированию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 141);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxChooseEventEdit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseEvent";
            this.Text = "Редактор";
            this.Load += new System.EventHandler(this.ChooseEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxChooseEventEdit;
        private System.Windows.Forms.Button button1;
    }
}