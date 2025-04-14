using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
    public partial class Add : Form
    {

        public Add()
        {
            InitializeComponent();
        }

        private void buttonAddParticipant_Click(object sender, EventArgs e)
        {
            string inputText = participantsOfEventField.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                checkedListBoxParticipants.Items.Add(inputText);
                participantsOfEventField.Clear();
            }
            else
            {
                MessageBox.Show("Введите текст перед добавлением", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteParticipant_Click(object sender, EventArgs e)
        {
            if (checkedListBoxParticipants.SelectedIndex != -1)
            {
                checkedListBoxParticipants.Items.RemoveAt(checkedListBoxParticipants.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            string nameOfEvent = nameOfEventField.Text;          
            DateTime dateTimeEvent = dateTimePickerEventField.Value; 
            string descriptionOfEvent = descriptionOfEventField.Text; 
            string categoryOfEvent = categoryOfEventField.Text;     
            TimeSpan timeOfEvent = TimeSpan.Parse(timeOfEventField.Text);
            string participantsOfEvent = checkedListBoxParticipants.Text;


            if (string.IsNullOrWhiteSpace(nameOfEvent) || string.IsNullOrWhiteSpace(descriptionOfEvent))
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimeEvent == DateTime.MinValue)
            {
                MessageBox.Show("Выберите корректную дату события", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3308;username=root;password=root; database=parties"))
                {
                    connection.Open();

                    string query = "INSERT INTO Events (nameOfEvent, dateOfEvent, descriptionOfEvent, CategoryOfEvent, Time, Participants) VALUES (@nameOfEvent, @dateOfEvent, @descriptionOfEvent, @CategoryOfEvent, @Time, @Participants)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nameOfEvent", nameOfEvent);
                        command.Parameters.AddWithValue("@dateOfEvent", dateTimeEvent);
                        command.Parameters.AddWithValue("@descriptionOfEvent", descriptionOfEvent);
                        command.Parameters.AddWithValue("@CategoryOfEvent", categoryOfEvent);
                        command.Parameters.AddWithValue("@Time", timeOfEvent);
                        List<string> selectedParticipants = new List<string>();

                        foreach (var item in checkedListBoxParticipants.Items)
                        {
                            int index = checkedListBoxParticipants.Items.IndexOf(item);
                            if (checkedListBoxParticipants.GetItemChecked(index))
                            {
                                // Убедитесь, что элемент является корректной строкой
                                if (item != null && !string.IsNullOrEmpty(item.ToString()))
                                {
                                    selectedParticipants.Add(item.ToString());
                                }
                            }
                        }

                        // Проверяем, что список не пуст
                        if (selectedParticipants.Count == 0)
                        {
                            MessageBox.Show("Выберите хотя бы одного участника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string jsonParticipants = JsonConvert.SerializeObject(selectedParticipants);
                        command.Parameters.AddWithValue("@Participants", jsonParticipants);


                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Событие успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить событие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }   
    }
}
