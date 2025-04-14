using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Project_Concerts
{
    public partial class Delete : Form
    {
        public Delete()
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
                            comboBoxDeleteEvent.Items.Clear(); // Очищаем ComboBox перед заполнением

                            while (reader.Read())
                            {
                                int eventId = reader.GetInt32("Eventid");
                                string eventName = reader.GetString("nameOfEvent");

                                // Добавляем элементы в ComboBox
                                comboBoxDeleteEvent.Items.Add(new { Id = eventId, Name = eventName });
                            }
                        }
                    }
                }

                // Настройка отображения данных в ComboBox
                comboBoxDeleteEvent.DisplayMember = "Name"; // Отображаемое значение
                comboBoxDeleteEvent.ValueMember = "Id";   // Скрытое значение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteEvent_Load(object sender, EventArgs e)
        {
            LoadEventsIntoComboBox();
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            // Проверяем, что событие выбрано
            if (comboBoxDeleteEvent.SelectedItem == null)
            {
                MessageBox.Show("Выберите событие для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Запрашиваем подтверждение у пользователя
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить это событие?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Получаем ID выбранного события
                var selectedEvent = comboBoxDeleteEvent.SelectedItem as dynamic;
                int eventId = selectedEvent.Id;

                try
                {
                    string connectionString = "server=localhost;port=3308;username=root;password=root;database=parties";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // SQL-запрос для удаления события
                        string query = "DELETE FROM Events WHERE Eventid = @Id";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", eventId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Событие успешно удалено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Обновляем ComboBox после удаления
                                LoadEventsIntoComboBox();
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить событие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Пользователь отменил удаление
                MessageBox.Show("Удаление отменено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
