using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
    public partial class Edit : Form
    {
        private int eventId;

        public Edit(int id)
        {
            InitializeComponent();
            this.eventId = id;

            // Загружаем данные события
            LoadEventData();
        }

        private void LoadEventData()
        {
            string connectionString = "server=localhost;port=3308;username=root;password=root;database=parties";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Events WHERE Eventid = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", eventId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxNameOfEventEdit.Text = reader.GetString("nameOfEvent");
                                dateTimePickerOfEventEdit.Value = reader.GetDateTime("dateOfEvent");
                                textBoxDescriptionOfEventEdit.Text = reader.GetString("descriptionOfEvent");
                                comboBoxCategoryOfEventEdit.Text = reader.GetString("CategoryOfEvent");
                                TimeSpan timeOffEvent = reader.GetTimeSpan("Time");
                                string timeString = timeOffEvent.ToString(@"hh\:mm\:ss"); // Форматирование времени
                                textBoxTimeOfEventEdit.Text = timeString;

                                // Преобразуем JSON участников в список
                                string participantsJson = reader.GetString("Participants");
                                List<string> participants = JsonConvert.DeserializeObject<List<string>>(participantsJson);
                                checkedListBoxParticipantsEdit.Items.Clear();
                                foreach (var participant in participants)
                                {
                                    checkedListBoxParticipantsEdit.Items.Add(participant, true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            string nameOfEvent = textBoxNameOfEventEdit.Text;
            DateTime dateOffEvent = dateTimePickerOfEventEdit.Value;
            string descriptionOfEvent = textBoxDescriptionOfEventEdit.Text;
            string categoryOfEvent = comboBoxCategoryOfEventEdit.Text;
            TimeSpan timeOfEventEdit = TimeSpan.Parse(textBoxTimeOfEventEdit.Text);

            List<string> participants = new List<string>();
            foreach (var item in checkedListBoxParticipantsEdit.CheckedItems)
            {
                participants.Add(item.ToString());
            }

            string participantsJson = JsonConvert.SerializeObject(participants);

            string connectionString = "server=localhost;port=3308;username=root;password=root;database=parties";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Events SET nameOfEvent = @Name, dateOfEvent = @Date, descriptionOfEvent = @Description, CategoryOfEvent = @Category, Time = @Time, Participants = @Participants WHERE Eventid = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", nameOfEvent);
                        command.Parameters.AddWithValue("@Date", dateOffEvent);
                        command.Parameters.AddWithValue("@Description", descriptionOfEvent);
                        command.Parameters.AddWithValue("@Category", categoryOfEvent);
                        command.Parameters.AddWithValue("@Time", timeOfEventEdit);
                        command.Parameters.AddWithValue("@Participants", participantsJson);
                        command.Parameters.AddWithValue("@Id", eventId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Событие успешно обновлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить событие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddParticipantEdit_Click(object sender, EventArgs e)
        {
            string inputText = participantOfEventEdit.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                checkedListBoxParticipantsEdit.Items.Add(inputText);
                participantOfEventEdit.Clear();
            }
            else
            {
                MessageBox.Show("Введите текст перед добавлением", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteParticipantEdit_Click(object sender, EventArgs e)
        {
            if (checkedListBoxParticipantsEdit.SelectedIndex != -1)
            {
                checkedListBoxParticipantsEdit.Items.RemoveAt(checkedListBoxParticipantsEdit.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
