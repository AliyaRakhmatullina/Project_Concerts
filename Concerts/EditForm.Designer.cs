namespace Concerts
{
    partial class EditForm
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
            this.label = new System.Windows.Forms.Label();
            this.textBoxNameOfEventEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerOfEventEdit = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTimeOfEventEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescriptionOfEventEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCategoryOfEventEdit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.participantOfEventEdit = new System.Windows.Forms.TextBox();
            this.buttonAddParticipantEdit = new System.Windows.Forms.Button();
            this.buttonDeleteParticipantEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkedListBoxParticipantsEdit = new System.Windows.Forms.CheckedListBox();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(265, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Название";
            // 
            // textBoxNameOfEventEdit
            // 
            this.textBoxNameOfEventEdit.Location = new System.Drawing.Point(268, 36);
            this.textBoxNameOfEventEdit.Name = "textBoxNameOfEventEdit";
            this.textBoxNameOfEventEdit.Size = new System.Drawing.Size(125, 20);
            this.textBoxNameOfEventEdit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата";
            // 
            // dateTimePickerOfEventEdit
            // 
            this.dateTimePickerOfEventEdit.Location = new System.Drawing.Point(268, 85);
            this.dateTimePickerOfEventEdit.Name = "dateTimePickerOfEventEdit";
            this.dateTimePickerOfEventEdit.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerOfEventEdit.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Время";
            // 
            // textBoxTimeOfEventEdit
            // 
            this.textBoxTimeOfEventEdit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxTimeOfEventEdit.Location = new System.Drawing.Point(268, 133);
            this.textBoxTimeOfEventEdit.Name = "textBoxTimeOfEventEdit";
            this.textBoxTimeOfEventEdit.Size = new System.Drawing.Size(125, 20);
            this.textBoxTimeOfEventEdit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Описание";
            // 
            // textBoxDescriptionOfEventEdit
            // 
            this.textBoxDescriptionOfEventEdit.Location = new System.Drawing.Point(268, 183);
            this.textBoxDescriptionOfEventEdit.Name = "textBoxDescriptionOfEventEdit";
            this.textBoxDescriptionOfEventEdit.Size = new System.Drawing.Size(125, 20);
            this.textBoxDescriptionOfEventEdit.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Категория";
            // 
            // comboBoxCategoryOfEventEdit
            // 
            this.comboBoxCategoryOfEventEdit.FormattingEnabled = true;
            this.comboBoxCategoryOfEventEdit.Items.AddRange(new object[] {
            "Сольный концерт",
            "Фестиваль",
            "Турне",
            "Открытый микрофон",
            "Кавер-концерт",
            "Благотворительный концерт"});
            this.comboBoxCategoryOfEventEdit.Location = new System.Drawing.Point(268, 242);
            this.comboBoxCategoryOfEventEdit.Name = "comboBoxCategoryOfEventEdit";
            this.comboBoxCategoryOfEventEdit.Size = new System.Drawing.Size(125, 21);
            this.comboBoxCategoryOfEventEdit.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Участники";
            // 
            // participantOfEventEdit
            // 
            this.participantOfEventEdit.Location = new System.Drawing.Point(268, 365);
            this.participantOfEventEdit.Name = "participantOfEventEdit";
            this.participantOfEventEdit.Size = new System.Drawing.Size(125, 20);
            this.participantOfEventEdit.TabIndex = 11;
            // 
            // buttonAddParticipantEdit
            // 
            this.buttonAddParticipantEdit.Location = new System.Drawing.Point(268, 391);
            this.buttonAddParticipantEdit.Name = "buttonAddParticipantEdit";
            this.buttonAddParticipantEdit.Size = new System.Drawing.Size(125, 23);
            this.buttonAddParticipantEdit.TabIndex = 12;
            this.buttonAddParticipantEdit.Text = "Добавить участника";
            this.buttonAddParticipantEdit.UseVisualStyleBackColor = true;
            this.buttonAddParticipantEdit.Click += new System.EventHandler(this.buttonAddParticipantEdit_Click);
            // 
            // buttonDeleteParticipantEdit
            // 
            this.buttonDeleteParticipantEdit.Location = new System.Drawing.Point(268, 415);
            this.buttonDeleteParticipantEdit.Name = "buttonDeleteParticipantEdit";
            this.buttonDeleteParticipantEdit.Size = new System.Drawing.Size(125, 23);
            this.buttonDeleteParticipantEdit.TabIndex = 13;
            this.buttonDeleteParticipantEdit.Text = "Удалить участника";
            this.buttonDeleteParticipantEdit.UseVisualStyleBackColor = true;
            this.buttonDeleteParticipantEdit.Click += new System.EventHandler(this.buttonDeleteParticipantEdit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Список участников";
            // 
            // checkedListBoxParticipantsEdit
            // 
            this.checkedListBoxParticipantsEdit.FormattingEnabled = true;
            this.checkedListBoxParticipantsEdit.Location = new System.Drawing.Point(12, 36);
            this.checkedListBoxParticipantsEdit.Name = "checkedListBoxParticipantsEdit";
            this.checkedListBoxParticipantsEdit.Size = new System.Drawing.Size(247, 349);
            this.checkedListBoxParticipantsEdit.TabIndex = 15;
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.Location = new System.Drawing.Point(12, 394);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(132, 23);
            this.buttonEditEvent.TabIndex = 16;
            this.buttonEditEvent.Text = "Сохранить изменения";
            this.buttonEditEvent.UseVisualStyleBackColor = true;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.buttonEditEvent);
            this.Controls.Add(this.checkedListBoxParticipantsEdit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonDeleteParticipantEdit);
            this.Controls.Add(this.buttonAddParticipantEdit);
            this.Controls.Add(this.participantOfEventEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxCategoryOfEventEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDescriptionOfEventEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTimeOfEventEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerOfEventEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNameOfEventEdit);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditForm";
            this.Text = "Редактор события";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBoxNameOfEventEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerOfEventEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTimeOfEventEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescriptionOfEventEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCategoryOfEventEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox participantOfEventEdit;
        private System.Windows.Forms.Button buttonAddParticipantEdit;
        private System.Windows.Forms.Button buttonDeleteParticipantEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkedListBoxParticipantsEdit;
        private System.Windows.Forms.Button buttonEditEvent;
    }
}