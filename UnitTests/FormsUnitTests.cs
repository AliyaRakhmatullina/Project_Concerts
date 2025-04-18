using System.Text.Json;
using System.Windows.Forms;
using Concerts;
using Concerts.DbModels;
using Xunit;

namespace UnitTests;

public class FormsUnitTests
{
    [Fact]
    public void AddFormWorks()
    {
        File.Delete("Test_AddFormWorks.db");
        ConcertsDbContext.DatabaseFilePath = "Test_AddFormWorks.db";
        
        using (var db0 = new ConcertsDbContext())
        {
            db0.Database.EnsureCreated();
        }

        var form = new AddForm(showMessageBoxes: false);

        form.NameOfEventField.Text = "event1name";
        form.DateTimePickerEventField.Value = new DateTime(2026, 02, 20);
        form.DescriptionOfEventField.Text = "event1 description";
        form.CategoryOfEventField.Text = "event1 category";
        form.TimeOfEventField.Text = "20:20";

        form.CheckedListBoxParticipants.Items.Add("p1", CheckState.Checked);
        form.CheckedListBoxParticipants.Items.Add("p2", CheckState.Unchecked);
        form.CheckedListBoxParticipants.Items.Add("p3", CheckState.Checked);

        form.buttonAddEvent_Click(new object(), EventArgs.Empty);

        using var db = new ConcertsDbContext();
        var events = db.Events.ToArray();

        // только 1 событие
        Assert.Single(events);

        var dbEvent = events[0];

        Assert.Equal("event1name", dbEvent.NameOfEvent);
        Assert.Equal(new DateTime(2026, 02, 20), dbEvent.DateOfEvent);
        Assert.Equal("event1 description", dbEvent.DescriptionOfEvent);
        Assert.Equal("event1 category", dbEvent.CategoryOfEvent);
        Assert.Equal("event1name", dbEvent.NameOfEvent);
        Assert.Equal("20:20", $"{dbEvent.Time.Hours}:{dbEvent.Time.Minutes}");

        var participants = new List<string>(["p1", "p3"]);
        var deserializedParticipants = JsonSerializer.Deserialize<List<string>>(dbEvent.ParticipantsJson);
        Assert.Equal(participants, deserializedParticipants);
    }

    [Fact]
    public void ChooseEventFormWorks()
    {
        File.Delete("Test_ChooseEventFormWorks.db");
        ConcertsDbContext.DatabaseFilePath = "Test_ChooseEventFormWorks.db";

        List<Event> events0 = new List<Event>()
        {
            new Event()
            {
                EventId = 1,
                NameOfEvent = "event1name",
                DateOfEvent = new DateTime(2026, 02, 20),
                DescriptionOfEvent = "event1 description",
                CategoryOfEvent = "event1 category",
                Time = new TimeSpan(20,20,0),
                ParticipantsJson = JsonSerializer.Serialize((string[])["p1", "p2", "p3"])
            },
            new Event()
            {
                EventId = 2,
                NameOfEvent = "event2name",
                DateOfEvent = new DateTime(2027, 07, 11),
                DescriptionOfEvent = "event2 description",
                CategoryOfEvent = "event2 category",
                Time = new TimeSpan(11,33,0),
                ParticipantsJson = JsonSerializer.Serialize((string[])["p11", "p22", "p33"])
            }
        };
        
        using (var db0 = new ConcertsDbContext())
        {
            db0.Database.EnsureCreated();
            db0.Events.AddRange(events0);
            db0.SaveChanges();
        }

        int idFromOnOpenEditForm = -1;
        void OnOpenEditForm(int id)
        {
            idFromOnOpenEditForm = id;
        }
        
        var chooseEventForm = new ChooseEventForm(showMessageBoxes: false, onOpenEditForm: OnOpenEditForm);
        chooseEventForm.ChooseEvent_Load(new object(), EventArgs.Empty);
        
        // проверка что все загружено
        Assert.Equal(events0.Count, chooseEventForm.ComboBoxChooseEventEdit.Items.Count);
        for (int i = 0; i < events0.Count; i++)
        {
            var event0 = events0[i];
            var eventFromComboBox = chooseEventForm.ComboBoxChooseEventEdit.Items[i] as ComboBoxChooseEventEditItem;
            Assert.Equal(event0.EventId, eventFromComboBox.Id);
            Assert.Equal(event0.NameOfEvent, eventFromComboBox.Name);
        }

        // проверка что нужный Event "передается" в "EditForm editFormForm = new EditForm(eventId)"
        chooseEventForm.ComboBoxChooseEventEdit.SelectedItem = chooseEventForm.ComboBoxChooseEventEdit.Items[1];
        chooseEventForm.button1_Click(new object(), EventArgs.Empty);
        Assert.Equal(events0[1].EventId, idFromOnOpenEditForm);
        
        // редактирование данных
        var events1 = events0.ToList(); // копия events0
        events1[1] = new Event()
        {
            EventId = 2,
            NameOfEvent = "event2name changed",
            DateOfEvent = new DateTime(2028, 08, 10),
            DescriptionOfEvent = "event2 description changed",
            CategoryOfEvent = "event2 category changed",
            Time = new TimeSpan(10, 30, 0),
            ParticipantsJson = JsonSerializer.Serialize((string[]) ["p11 changed", "p22 changed", "p33 changed"])
        };
        
        using (var db0 = new ConcertsDbContext())
        {
            db0.Events.Update(events1[1]);
            db0.SaveChanges();
        }
        
        // обновляем данные после редактирования
        chooseEventForm.LoadEventsIntoComboBox();
        
        // проверка что все загружено
        Assert.Equal(events1.Count, chooseEventForm.ComboBoxChooseEventEdit.Items.Count);
        for (int i = 0; i < events1.Count; i++)
        {
            var event1 = events1[i];
            var eventFromComboBox = chooseEventForm.ComboBoxChooseEventEdit.Items[i] as ComboBoxChooseEventEditItem;
            Assert.Equal(event1.EventId, eventFromComboBox.Id);
            Assert.Equal(event1.NameOfEvent, eventFromComboBox.Name);
        }
    }

    [Fact]
    public void EditFormWorks()
    {
        File.Delete("Test_EditFormWorks.db");
        ConcertsDbContext.DatabaseFilePath = "Test_EditFormWorks.db";

        List<Event> events0 = new List<Event>()
        {
            new Event()
            {
                EventId = 1,
                NameOfEvent = "event1name",
                DateOfEvent = new DateTime(2026, 02, 20),
                DescriptionOfEvent = "event1 description",
                CategoryOfEvent = "event1 category",
                Time = new TimeSpan(20, 20, 0),
                ParticipantsJson = JsonSerializer.Serialize((string[]) ["p1", "p2", "p3"])
            },
            new Event()
            {
                EventId = 2,
                NameOfEvent = "event2name",
                DateOfEvent = new DateTime(2027, 07, 11),
                DescriptionOfEvent = "event2 description",
                CategoryOfEvent = "event2 category",
                Time = new TimeSpan(11, 33, 0),
                ParticipantsJson = JsonSerializer.Serialize((string[]) ["p11", "p22", "p33"])
            }
        };
        
        using (var db0 = new ConcertsDbContext())
        {
            db0.Database.EnsureCreated();
            db0.Events.AddRange(events0);
            db0.SaveChanges();
        }

        var event2 = new Event()
        {
            EventId = 2,
            NameOfEvent = "event2name changed",
            DateOfEvent = new DateTime(2029, 11, 13),
            DescriptionOfEvent = "event2 description changed",
            CategoryOfEvent = "event2 category changed",
            Time = new TimeSpan(12, 44, 0),
            ParticipantsJson = JsonSerializer.Serialize((string[]) ["p11 changed", "p22 changed", "p33 changed"])
        };
        
        var events1 = events0.ToList();
        events1[1] = event2;
        
        var editForm = new EditForm(2, showMessageBoxes: false);

        editForm.TextBoxNameOfEventEdit.Text = event2.NameOfEvent;
        editForm.DateTimePickerOfEventEdit.Value = event2.DateOfEvent;
        editForm.ComboBoxCategoryOfEventEdit.Text = event2.CategoryOfEvent;
        editForm.TextBoxDescriptionOfEventEdit.Text = event2.DescriptionOfEvent;
        editForm.TextBoxTimeOfEventEdit.Text = event2.Time.ToString(@"hh\:mm\:ss");
        var participants2 = JsonSerializer.Deserialize<string[]>(event2.ParticipantsJson);
        editForm.CheckedListBoxParticipantsEdit.Items.Clear();
        foreach (var participant2 in participants2)
        {
            editForm.CheckedListBoxParticipantsEdit.Items.Add(participant2, CheckState.Checked);
        }

        editForm.buttonEditEvent_Click(new object(), EventArgs.Empty);
        
        using (var db0 = new ConcertsDbContext())
        {
            var dbEvents = db0.Events.ToArray();
            
            Assert.Equal(events1.Count, dbEvents.Length);

            for (int i = 0; i < events1.Count; i++)
            {
                var event1 = events1[i];
                var dbEvent = dbEvents[i];
                
                Assert.Equal(event1.EventId, dbEvent.EventId);
                Assert.Equal(event1.NameOfEvent, dbEvent.NameOfEvent);
                Assert.Equal(event1.DateOfEvent, dbEvent.DateOfEvent);
                Assert.Equal(event1.DescriptionOfEvent, dbEvent.DescriptionOfEvent);
                Assert.Equal(event1.CategoryOfEvent, dbEvent.CategoryOfEvent);
                Assert.Equal(event1.Time, dbEvent.Time);
                Assert.Equal(event1.ParticipantsJson, dbEvent.ParticipantsJson);
            }
            
        }
    }

    [Fact]
    public void DeleteFormWorks()
    {
        File.Delete("Test_DeleteFormWorks.db");
        ConcertsDbContext.DatabaseFilePath = "Test_DeleteFormWorks.db";

        List<Event> events0 = new List<Event>()
        {
            new Event()
            {
                EventId = 1,
                NameOfEvent = "event1name",
                DateOfEvent = new DateTime(2026, 02, 20),
                DescriptionOfEvent = "event1 description",
                CategoryOfEvent = "event1 category",
                Time = new TimeSpan(20, 20, 0),
                ParticipantsJson = JsonSerializer.Serialize((string[]) ["p1", "p2", "p3"])
            },
            new Event()
            {
                EventId = 2,
                NameOfEvent = "event2name",
                DateOfEvent = new DateTime(2027, 07, 11),
                DescriptionOfEvent = "event2 description",
                CategoryOfEvent = "event2 category",
                Time = new TimeSpan(11, 33, 0),
                ParticipantsJson = JsonSerializer.Serialize((string[]) ["p11", "p22", "p33"])
            }
        };

        using (var db0 = new ConcertsDbContext())
        {
            db0.Database.EnsureCreated();
            db0.Events.AddRange(events0);
            db0.SaveChanges();
        }
        
        var deleteForm = new DeleteForm(showMessageBoxes: false, requestDeletionAccept: false);

        deleteForm.DeleteEvent_Load(new object(), EventArgs.Empty);

        deleteForm.ComboBoxDeleteEvent.SelectedIndex = 1;
        
        deleteForm.buttonDeleteEvent_Click(new object(), EventArgs.Empty);
        
        using (var db1 = new ConcertsDbContext())
        {
            db1.Database.EnsureCreated();
            var events1 = db1.Events.ToArray();
            Assert.Single(events1);

            var event0 = events0[0];
            var event1 = events1[0];
            
            Assert.Equal(event0.EventId, event1.EventId);
            Assert.Equal(event0.NameOfEvent, event1.NameOfEvent);
            Assert.Equal(event0.DateOfEvent, event1.DateOfEvent);
            Assert.Equal(event0.DescriptionOfEvent, event1.DescriptionOfEvent);
            Assert.Equal(event0.CategoryOfEvent, event1.CategoryOfEvent);
            Assert.Equal(event0.NameOfEvent, event1.NameOfEvent);
            Assert.Equal(event0.Time, event1.Time);
            Assert.Equal(event0.ParticipantsJson, event1.ParticipantsJson);
        }
    }
}