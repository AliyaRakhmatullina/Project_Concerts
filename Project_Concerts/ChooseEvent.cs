using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Concerts
{
    public partial class ChooseEvent : Form
    {
        public ChooseEvent()
        {
            InitializeComponent();
        }

        private void LoadEventsIntoComboBox()
        {
            string connectionString = "server=localhost;port=3308;username=root;password=root;database=parties";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Eventid, nameOfEvent FROM Events";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxChooseEventEdit.Items.Clear(); // Очищаем ComboBox перед заполнением

                            while (reader.Read())
                            {
                                int eventId = reader.GetInt32("Eventid");
                                string eventName = reader.GetString("nameOfEvent");

                                // Добавляем элементы в ComboBox
                                comboBoxChooseEventEdit.Items.Add(new { Id = eventId, Name = eventName });
                            }
                        }
                    }
                }

                // Настройка отображения данных в ComboBox
                comboBoxChooseEventEdit.DisplayMember = "Name"; // Отображаемое значение
                comboBoxChooseEventEdit.ValueMember = "Id";   // Скрытое значение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChooseEvent_Load(object sender, EventArgs e)
        {
            LoadEventsIntoComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseEventEdit.SelectedItem == null)
            {
                MessageBox.Show("Выберите событие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEvent = comboBoxChooseEventEdit.SelectedItem as dynamic;
            int eventId = selectedEvent.Id;

            // Открываем форму редактирования
            Edit editForm = new Edit(eventId); // Передаем ID события
            editForm.ShowDialog();

            // Обновляем данные после редактирования
            LoadEventsIntoComboBox();
        }


    }
}
