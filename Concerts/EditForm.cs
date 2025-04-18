using Concerts;
using System.Text.Json;

namespace Concerts
{
    public partial class EditForm : Form
    {
        private int eventId;
        private readonly bool _showMessageBoxes;

        public EditForm(int id, bool showMessageBoxes = true)
        {
            InitializeComponent();
            this.eventId = id;
            _showMessageBoxes = showMessageBoxes;

            // Загружаем данные события
            LoadEventData();
        }

        public TextBox TextBoxNameOfEventEdit => textBoxNameOfEventEdit;
        public DateTimePicker DateTimePickerOfEventEdit => dateTimePickerOfEventEdit;
        public TextBox TextBoxDescriptionOfEventEdit => textBoxDescriptionOfEventEdit;
        public ComboBox ComboBoxCategoryOfEventEdit => comboBoxCategoryOfEventEdit;
        public TextBox TextBoxTimeOfEventEdit => textBoxTimeOfEventEdit;
        public CheckedListBox CheckedListBoxParticipantsEdit => checkedListBoxParticipantsEdit;
        
        private void LoadEventData()
        {
            try
            {
                using ConcertsDbContext dbContext = new ConcertsDbContext();

                var dbEvent = dbContext.Events.First(dbEvent => dbEvent.EventId == eventId);


                textBoxNameOfEventEdit.Text = dbEvent.NameOfEvent;//.GetString("nameOfEvent");
                dateTimePickerOfEventEdit.Value = dbEvent.DateOfEvent;// reader.GetDateTime("dateOfEvent");
                textBoxDescriptionOfEventEdit.Text = dbEvent.DescriptionOfEvent;// reader.GetString("descriptionOfEvent");
                comboBoxCategoryOfEventEdit.Text = dbEvent.CategoryOfEvent;// reader.GetString("CategoryOfEvent");
                TimeSpan timeOffEvent = dbEvent.Time;// reader.GetTimeSpan("Time");
                string timeString = timeOffEvent.ToString(@"hh\:mm\:ss"); // Форматирование времени
                textBoxTimeOfEventEdit.Text = timeString;

                List<string> participants = JsonSerializer.Deserialize<List<string>>(dbEvent.ParticipantsJson);
                checkedListBoxParticipantsEdit.Items.Clear();
                foreach (var participant in participants)
                {
                    checkedListBoxParticipantsEdit.Items.Add(participant, true);
                }
            }
            catch (Exception ex)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new InvalidOperationException($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        public void buttonEditEvent_Click(object sender, EventArgs e)
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

            string participantsJson = JsonSerializer.Serialize(participants);


            try
            {
                using ConcertsDbContext dbContext = new ConcertsDbContext();

                var dbEvent = dbContext.Events.First(e => e.EventId == eventId);

                dbEvent.NameOfEvent = nameOfEvent;
                dbEvent.DateOfEvent = dateOffEvent;
                dbEvent.DescriptionOfEvent = descriptionOfEvent;
                dbEvent.CategoryOfEvent = categoryOfEvent;
                dbEvent.Time = timeOfEventEdit;
                dbEvent.ParticipantsJson = participantsJson;

                dbContext.Events.Update(dbEvent);

                var rowsAffected = dbContext.SaveChanges();

                if (rowsAffected > 0)
                {
                    if (_showMessageBoxes)
                    {
                        MessageBox.Show("Событие успешно обновлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    if (_showMessageBoxes)
                    {
                        MessageBox.Show("Не удалось обновить событие.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        throw new InvalidOperationException("Не удалось обновить событие.");
                    }
                }

            }
            catch (Exception ex)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new InvalidOperationException($"Ошибка при обновлении данных: {ex.Message}");
                }
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
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Введите текст перед добавлением", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Введите текст перед добавлением");
                }
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
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Выберите элемент для удаления");
                }
            }
        }
    }
}
