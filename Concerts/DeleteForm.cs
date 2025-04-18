using Concerts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concerts
{
    public class ComboBoxDeleteEventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class DeleteForm : Form
    {
        private readonly bool _showMessageBoxes;
        private readonly bool _requestDeletionAccept;

        public DeleteForm(bool showMessageBoxes = true, bool requestDeletionAccept = true)
        {
            _showMessageBoxes = showMessageBoxes;
            _requestDeletionAccept = requestDeletionAccept;
            InitializeComponent();
        }

        private void LoadEventsIntoComboBox()
        {
            try
            {
                using ConcertsDbContext dbContext = new ConcertsDbContext();

                comboBoxDeleteEvent.Items.Clear(); // Очищаем ComboBox перед заполнением

                var dbEvents = dbContext.Events.ToList();

                foreach (var dbEvent in dbEvents)
                {
                    // Добавляем элементы в ComboBox
                    comboBoxDeleteEvent.Items.Add(new ComboBoxDeleteEventItem(){ Id = dbEvent.EventId, Name = dbEvent.NameOfEvent });
                }

                // Настройка отображения данных в ComboBox
                comboBoxDeleteEvent.DisplayMember = "Name"; // Отображаемое значение
                comboBoxDeleteEvent.ValueMember = "Id"; // Скрытое значение
            }
            catch (Exception ex)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show($"Ошибка при загрузке событий: {ex.Message}", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    throw new InvalidOperationException($"Ошибка при загрузке событий: {ex.Message}");
                }
            }
        }

        public void DeleteEvent_Load(object sender, EventArgs e)
        {
            LoadEventsIntoComboBox();
        }

        public ComboBox ComboBoxDeleteEvent => comboBoxDeleteEvent;
        
        public void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            // Проверяем, что событие выбрано
            if (comboBoxDeleteEvent.SelectedItem == null)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Выберите событие для удаления!", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Выберите событие для удаления!");
                }

                return;
            }

            DialogResult result;
            if (_requestDeletionAccept)
            {
                // Запрашиваем подтверждение у пользователя
                result = MessageBox.Show(
                    "Вы уверены, что хотите удалить это событие?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            }
            else
            {
                result = DialogResult.Yes;
            }


            if (result == DialogResult.Yes)
            {
                // Получаем ID выбранного события
                var selectedEvent = comboBoxDeleteEvent.SelectedItem as dynamic;
                int eventId = selectedEvent.Id;

                try
                {
                    using ConcertsDbContext dbContext = new ConcertsDbContext();

                    int rowsAffected = dbContext.Events.Where(dbEvent => dbEvent.EventId == eventId).ExecuteDelete();

                    dbContext.SaveChanges();

                    if (rowsAffected > 0)
                    {
                        if (_showMessageBoxes)
                        {
                            MessageBox.Show("Событие успешно удалено!", "Успех", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                        // Обновляем ComboBox после удаления
                        LoadEventsIntoComboBox();
                    }
                    else
                    {
                        if (_showMessageBoxes)
                        {
                            MessageBox.Show("Не удалось удалить событие.", "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw new InvalidOperationException("Не удалось удалить событие.");
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
            else
            {
                if (_showMessageBoxes)
                {
                    // Пользователь отменил удаление
                    MessageBox.Show("Удаление отменено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new InvalidOperationException("Удаление отменено.");
                }
            }
        }
    }
}