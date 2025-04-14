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
    public partial class Watch : Form
    {
        public Watch()
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
                            comboBoxLoadEvents.Items.Clear(); // Очищаем ComboBox перед заполнением

                            while (reader.Read())
                            {
                                int eventId = reader.GetInt32("Eventid");
                                string eventName = reader.GetString("nameOfEvent");

                                // Добавляем элементы в ComboBox
                                comboBoxLoadEvents.Items.Add(new { Id = eventId, Name = eventName });
                            }
                        }
                    }
                }

                // Настройка отображения данных в ComboBox
                comboBoxLoadEvents.DisplayMember = "Name"; // Отображаемое значение
                comboBoxLoadEvents.ValueMember = "Id";   // Скрытое значение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Watch_Load(object sender, EventArgs e)
        {
            LoadEventsIntoComboBox();
        }


        private void buttonShowEvent_Click(object sender, EventArgs e)
        {
            if (comboBoxLoadEvents.SelectedItem == null)
            {
                MessageBox.Show("Выберите событие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedEvent = comboBoxLoadEvents.SelectedItem as dynamic;
            int eventId = selectedEvent.Id;

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

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (!string.IsNullOrEmpty(row["Participants"].ToString()))
                            {
                                // Преобразуем JSON-массив в строку через запятую
                                string participantsJson = row["Participants"].ToString();
                                List<string> participants = JsonConvert.DeserializeObject<List<string>>(participantsJson);
                                row["Participants"] = string.Join(", ", participants);
                            }
                        }

                        // Привязываем данные к DataGridView
                        dataGridViewEvents.DataSource = dataTable;
                        // Удаляем первый столбец
                        if (dataGridViewEvents.Columns.Count > 0)
                        {
                            dataGridViewEvents.Columns.RemoveAt(0);
                        }
                        // Устанавливаем пользовательские заголовки
                        if (dataGridViewEvents.Columns.Count > 0)
                        {
                            dataGridViewEvents.Columns[0].HeaderText = "Название события";
                            dataGridViewEvents.Columns[1].HeaderText = "Дата события";
                            dataGridViewEvents.Columns[2].HeaderText = "Время события";
                            dataGridViewEvents.Columns[3].HeaderText = "Описание";
                            dataGridViewEvents.Columns[4].HeaderText = "Категория";
                            dataGridViewEvents.Columns[5].HeaderText = "Участники";
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
