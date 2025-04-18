using Concerts;
using System.Data;
using System.Text.Json;

namespace Concerts
{
    public partial class Watch : Form
    {
        public Watch()
        {
            InitializeComponent();
        }

        private void LoadEventsIntoComboBox()
        {
            try
            {
                using ConcertsDbContext dbContext = new ConcertsDbContext();

                var dbEvents = dbContext.Events.ToList();
                comboBoxLoadEvents.Items.Clear(); // Очищаем ComboBox перед заполнением

                foreach (var dbEvent in dbEvents)
                {
                    // Добавляем элементы в ComboBox
                    comboBoxLoadEvents.Items.Add(new { Id = dbEvent.EventId, Name = dbEvent.NameOfEvent });
                }

                // Настройка отображения данных в ComboBox
                comboBoxLoadEvents.DisplayMember = "Name"; // Отображаемое значение
                comboBoxLoadEvents.ValueMember = "Id"; // Скрытое значение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                using ConcertsDbContext dbContext = new ConcertsDbContext();
                var dbEvent = dbContext.Events.First(e => e.EventId == eventId);

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("EventId", typeof(int));
                dataTable.Columns.Add("NameOfEvent", typeof(string));
                dataTable.Columns.Add("DateOfEvent", typeof(DateTime));
                dataTable.Columns.Add("DescriptionOfEvent", typeof(string));
                dataTable.Columns.Add("CategoryOfEvent", typeof(string));
                dataTable.Columns.Add("Time", typeof(TimeSpan));
                dataTable.Columns.Add("ParticipantsJson", typeof(string));

                dataTable.Rows.Add([
                    dbEvent.EventId, dbEvent.NameOfEvent, dbEvent.DateOfEvent, dbEvent.DescriptionOfEvent,
                    dbEvent.CategoryOfEvent, dbEvent.Time, dbEvent.ParticipantsJson
                ]);

                var row = dataTable.Rows[0];
                if (!string.IsNullOrEmpty(row["ParticipantsJson"].ToString()))
                {
                    // Преобразуем JSON-массив в строку через запятую
                    string participantsJson = row["ParticipantsJson"].ToString();
                    List<string> participants = JsonSerializer.Deserialize<List<string>>(participantsJson);
                    row["ParticipantsJson"] = string.Join(", ", participants);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}