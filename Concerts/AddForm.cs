using System.Text.Json;
using Concerts;
using Concerts.DbModels;

namespace Concerts
{
    public partial class AddForm : Form
    {
        private readonly bool _showMessageBoxes;

        public AddForm(bool showMessageBoxes = true)
        {
            _showMessageBoxes = showMessageBoxes;
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
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Введите текст перед добавлением", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Введите текст перед добавлением");
                }
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
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Выберите элемент для удаления");
                }
            }
        }

        public TextBox NameOfEventField => nameOfEventField;
        public DateTimePicker DateTimePickerEventField => dateTimePickerEventField;
        public TextBox DescriptionOfEventField => descriptionOfEventField;
        public ComboBox CategoryOfEventField => categoryOfEventField;
        public TextBox TimeOfEventField => timeOfEventField;
        public CheckedListBox CheckedListBoxParticipants => checkedListBoxParticipants;

        public void buttonAddEvent_Click(object sender, EventArgs e)
        {
            string nameOfEvent = nameOfEventField.Text;
            DateTime dateTimeEvent = dateTimePickerEventField.Value;
            string descriptionOfEvent = descriptionOfEventField.Text;
            string categoryOfEvent = categoryOfEventField.Text;
            TimeSpan timeOfEvent = TimeSpan.Parse(timeOfEventField.Text);
            //string participantsOfEvent = checkedListBoxParticipants.Text;


            if (string.IsNullOrWhiteSpace(nameOfEvent) || string.IsNullOrWhiteSpace(descriptionOfEvent))
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Заполните все обязательные поля", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Заполните все обязательные поля");
                }

                return;
            }

            if (dateTimeEvent == DateTime.MinValue)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Выберите корректную дату события", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Выберите корректную дату события");
                }

                return;
            }

            try
            {
                using var dbContext = new ConcertsDbContext();

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
                    if (_showMessageBoxes)
                    {
                        MessageBox.Show("Выберите хотя бы одного участника!", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        throw new InvalidOperationException("Выберите хотя бы одного участника!");
                    }

                    return;
                }

                string jsonParticipants = JsonSerializer.Serialize(selectedParticipants);

                var dbEvent = new Event()
                {
                    NameOfEvent = nameOfEvent,
                    DateOfEvent = dateTimeEvent,
                    DescriptionOfEvent = descriptionOfEvent,
                    Time = timeOfEvent,
                    CategoryOfEvent = categoryOfEvent,
                    ParticipantsJson = jsonParticipants
                };
                dbContext.Events.Add(dbEvent);

                int rowsAffected = dbContext.SaveChanges();
                if (rowsAffected > 0)
                {
                    if (_showMessageBoxes)
                    {
                        MessageBox.Show("Событие успешно добавлено!", "Успех", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (_showMessageBoxes)
                    {
                        MessageBox.Show("Не удалось добавить событие.", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        throw new InvalidOperationException("Не удалось добавить событие.");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    throw new InvalidOperationException($"Произошла ошибка: {ex.Message}");
                }
            }
        }
    }
}