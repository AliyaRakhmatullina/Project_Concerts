using Concerts;

namespace Concerts
{
    public class ComboBoxChooseEventEditItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public partial class ChooseEventForm : Form
    {
        private readonly bool _showMessageBoxes;
        private readonly Action<int>? _onOpenEditForm;

        public ChooseEventForm(bool showMessageBoxes = true, Action<int>? onOpenEditForm = null)
        {
            _showMessageBoxes = showMessageBoxes;
            _onOpenEditForm = onOpenEditForm;
            InitializeComponent();
        }

        public ComboBox ComboBoxChooseEventEdit => comboBoxChooseEventEdit;
        
        public void LoadEventsIntoComboBox()
        {
            try
            {
                using var dbContext = new ConcertsDbContext();

                var dbEvents = dbContext.Events.ToList();

                comboBoxChooseEventEdit.Items.Clear(); // Очищаем ComboBox перед заполнением

                foreach (var dbEvent in dbEvents)
                {
                    // Добавляем элементы в ComboBox
                    comboBoxChooseEventEdit.Items.Add(new ComboBoxChooseEventEditItem() { Id = dbEvent.EventId, Name = dbEvent.NameOfEvent });
                }

                // Настройка отображения данных в ComboBox
                comboBoxChooseEventEdit.DisplayMember = "Name"; // Отображаемое значение
                comboBoxChooseEventEdit.ValueMember = "Id"; // Скрытое значение
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

        public void ChooseEvent_Load(object sender, EventArgs e)
        {
            LoadEventsIntoComboBox();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxChooseEventEdit.SelectedItem == null)
            {
                if (_showMessageBoxes)
                {
                    MessageBox.Show("Выберите событие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new InvalidOperationException("Выберите событие!");
                }
                return;
            }

            var selectedEvent = comboBoxChooseEventEdit.SelectedItem as dynamic;
            int eventId = selectedEvent.Id;

            // Открываем форму редактирования
            if (_onOpenEditForm == null)
            {
                EditForm editFormForm = new EditForm(eventId); // Передаем ID события
                editFormForm.ShowDialog();
            }
            else
            {
                _onOpenEditForm(eventId);
            }
            

            // Обновляем данные после редактирования
            LoadEventsIntoComboBox();
        }
    }
}