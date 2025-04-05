namespace Project_Concerts
{
    partial class Add
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
            this.nameOfEvent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddParticipant = new System.Windows.Forms.Button();
            this.buttonDeleteParticipant = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxParticipants = new System.Windows.Forms.TextBox();
            this.checkedListBoxParticipants = new System.Windows.Forms.CheckedListBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameOfEvent
            // 
            this.nameOfEvent.Location = new System.Drawing.Point(12, 36);
            this.nameOfEvent.Name = "nameOfEvent";
            this.nameOfEvent.Size = new System.Drawing.Size(125, 20);
            this.nameOfEvent.TabIndex = 0;
            this.nameOfEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePickerEvent
            // 
            this.dateTimePickerEvent.Location = new System.Drawing.Point(12, 87);
            this.dateTimePickerEvent.MinDate = new System.DateTime(2025, 4, 5, 0, 0, 0, 0);
            this.dateTimePickerEvent.Name = "dateTimePickerEvent";
            this.dateTimePickerEvent.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerEvent.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Время";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(12, 140);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(125, 20);
            this.textBoxTime.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Описание";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(12, 193);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(125, 20);
            this.textBoxDescription.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Категория";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Items.AddRange(new object[] {
            "Сольный концерт",
            "Фестиваль",
            "Турне",
            "Открытый микрофон",
            "Кавер-концерт",
            "Благотворительный концерт"});
            this.comboBoxCategories.Location = new System.Drawing.Point(12, 244);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(125, 21);
            this.comboBoxCategories.TabIndex = 9;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Участники";
            // 
            // buttonAddParticipant
            // 
            this.buttonAddParticipant.Location = new System.Drawing.Point(12, 341);
            this.buttonAddParticipant.Name = "buttonAddParticipant";
            this.buttonAddParticipant.Size = new System.Drawing.Size(125, 23);
            this.buttonAddParticipant.TabIndex = 12;
            this.buttonAddParticipant.Text = "Добавить участника";
            this.buttonAddParticipant.UseVisualStyleBackColor = true;
            this.buttonAddParticipant.Click += new System.EventHandler(this.buttonAddParticipant_Click);
            // 
            // buttonDeleteParticipant
            // 
            this.buttonDeleteParticipant.Location = new System.Drawing.Point(12, 394);
            this.buttonDeleteParticipant.Name = "buttonDeleteParticipant";
            this.buttonDeleteParticipant.Size = new System.Drawing.Size(125, 23);
            this.buttonDeleteParticipant.TabIndex = 13;
            this.buttonDeleteParticipant.Text = "Удалить участника";
            this.buttonDeleteParticipant.UseVisualStyleBackColor = true;
            this.buttonDeleteParticipant.Click += new System.EventHandler(this.buttonDeleteParticipant_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Список участников";
            // 
            // textBoxParticipants
            // 
            this.textBoxParticipants.Location = new System.Drawing.Point(12, 299);
            this.textBoxParticipants.Name = "textBoxParticipants";
            this.textBoxParticipants.Size = new System.Drawing.Size(125, 20);
            this.textBoxParticipants.TabIndex = 15;
            // 
            // checkedListBoxParticipants
            // 
            this.checkedListBoxParticipants.FormattingEnabled = true;
            this.checkedListBoxParticipants.Location = new System.Drawing.Point(198, 36);
            this.checkedListBoxParticipants.Name = "checkedListBoxParticipants";
            this.checkedListBoxParticipants.Size = new System.Drawing.Size(247, 349);
            this.checkedListBoxParticipants.TabIndex = 16;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(198, 394);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(126, 23);
            this.buttonAddEvent.TabIndex = 17;
            this.buttonAddEvent.Text = "Добавить событие";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 450);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.checkedListBoxParticipants);
            this.Controls.Add(this.textBoxParticipants);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonDeleteParticipant);
            this.Controls.Add(this.buttonAddParticipant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerEvent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameOfEvent);
            this.Name = "Add";
            this.Text = "Добавление события";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameOfEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddParticipant;
        private System.Windows.Forms.Button buttonDeleteParticipant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxParticipants;
        private System.Windows.Forms.CheckedListBox checkedListBoxParticipants;
        private System.Windows.Forms.Button buttonAddEvent;
    }
}