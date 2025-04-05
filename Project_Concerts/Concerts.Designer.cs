namespace Project_Concerts
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSorting = new System.Windows.Forms.GroupBox();
            this.radioButtonCategory = new System.Windows.Forms.RadioButton();
            this.radioButtonDate = new System.Windows.Forms.RadioButton();
            this.radioButtonOrder = new System.Windows.Forms.RadioButton();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonParticipants = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameOfEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionOfEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoriesOfEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParticipantsOfEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxSorting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSorting
            // 
            this.groupBoxSorting.Controls.Add(this.radioButtonCategory);
            this.groupBoxSorting.Controls.Add(this.radioButtonDate);
            this.groupBoxSorting.Controls.Add(this.radioButtonOrder);
            this.groupBoxSorting.Location = new System.Drawing.Point(5, 69);
            this.groupBoxSorting.Name = "groupBoxSorting";
            this.groupBoxSorting.Size = new System.Drawing.Size(351, 51);
            this.groupBoxSorting.TabIndex = 0;
            this.groupBoxSorting.TabStop = false;
            this.groupBoxSorting.Text = "Сортировка";
            // 
            // radioButtonCategory
            // 
            this.radioButtonCategory.AutoSize = true;
            this.radioButtonCategory.Location = new System.Drawing.Point(168, 19);
            this.radioButtonCategory.Name = "radioButtonCategory";
            this.radioButtonCategory.Size = new System.Drawing.Size(94, 17);
            this.radioButtonCategory.TabIndex = 2;
            this.radioButtonCategory.TabStop = true;
            this.radioButtonCategory.Text = "По категории";
            this.radioButtonCategory.UseVisualStyleBackColor = true;
            this.radioButtonCategory.CheckedChanged += new System.EventHandler(this.radioButtonCategory_CheckedChanged);
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Location = new System.Drawing.Point(95, 19);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(65, 17);
            this.radioButtonDate.TabIndex = 1;
            this.radioButtonDate.TabStop = true;
            this.radioButtonDate.Text = "По дате";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            // 
            // radioButtonOrder
            // 
            this.radioButtonOrder.AutoSize = true;
            this.radioButtonOrder.Location = new System.Drawing.Point(6, 19);
            this.radioButtonOrder.Name = "radioButtonOrder";
            this.radioButtonOrder.Size = new System.Drawing.Size(83, 17);
            this.radioButtonOrder.TabIndex = 0;
            this.radioButtonOrder.TabStop = true;
            this.radioButtonOrder.Text = "По порядку";
            this.radioButtonOrder.UseVisualStyleBackColor = true;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(362, 119);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(288, 319);
            this.textBoxDescription.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 31);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(137, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить событие";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonParticipants
            // 
            this.buttonParticipants.Location = new System.Drawing.Point(164, 31);
            this.buttonParticipants.Name = "buttonParticipants";
            this.buttonParticipants.Size = new System.Drawing.Size(148, 23);
            this.buttonParticipants.TabIndex = 4;
            this.buttonParticipants.Text = "Список участников";
            this.buttonParticipants.UseVisualStyleBackColor = true;
            this.buttonParticipants.Click += new System.EventHandler(this.buttonParticipants_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(330, 31);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(151, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Редактировать событие";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(496, 31);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(154, 23);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удалить событие";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Описание события";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameOfEvent,
            this.DateOfEvent,
            this.DescriptionOfEvent,
            this.CategoriesOfEvent,
            this.ParticipantsOfEvent});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 119);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(351, 319);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // NameOfEvent
            // 
            this.NameOfEvent.Text = "Название";
            // 
            // DateOfEvent
            // 
            this.DateOfEvent.Text = "Дата";
            // 
            // DescriptionOfEvent
            // 
            this.DescriptionOfEvent.Text = "Описание";
            // 
            // CategoriesOfEvent
            // 
            this.CategoriesOfEvent.Text = "Категория";
            // 
            // ParticipantsOfEvent
            // 
            this.ParticipantsOfEvent.Text = "Участники";
            this.ParticipantsOfEvent.Width = 81;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonParticipants);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.groupBoxSorting);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name = "Form1";
            this.Text = "Концерты и музыкальные фестивали";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSorting.ResumeLayout(false);
            this.groupBoxSorting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSorting;
        private System.Windows.Forms.RadioButton radioButtonCategory;
        private System.Windows.Forms.RadioButton radioButtonDate;
        private System.Windows.Forms.RadioButton radioButtonOrder;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonParticipants;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NameOfEvent;
        private System.Windows.Forms.ColumnHeader DateOfEvent;
        private System.Windows.Forms.ColumnHeader DescriptionOfEvent;
        private System.Windows.Forms.ColumnHeader CategoriesOfEvent;
        private System.Windows.Forms.ColumnHeader ParticipantsOfEvent;
    }
}

