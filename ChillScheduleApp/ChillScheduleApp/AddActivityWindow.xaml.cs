using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ChillScheduleApp
{
    public partial class AddActivityWindow : Window
    {
        private ObservableCollection<Activity> activities;

        public AddActivityWindow(ObservableCollection<Activity> activities)
        {
            InitializeComponent();
            this.activities = activities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string activityName = ActivityNameTextBox.Text;
            DateTime? startTime = StartDatePicker.SelectedDate;
            DateTime? endTime = EndDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(activityName))
            {
                MessageBox.Show("Введите название мероприятия.");
                return;
            }

            if (startTime == null || endTime == null || endTime <= startTime)
            {
                MessageBox.Show("Время окончания должно быть позже времени начала.");
                return;
            }

            if (IsOverlapping(startTime.Value, endTime.Value))
            {
                MessageBox.Show("Чувак, у тебя уже есть планы на это время!");
                return;
            }

            activities.Add(new Activity { Name = activityName, StartTime = startTime.Value, EndTime = endTime.Value });
            DialogResult = true;
            Close();
        }

        private bool IsOverlapping(DateTime startTime, DateTime endTime)
        {
            foreach (var activity in activities)
            {
                if (startTime < activity.EndTime && endTime > activity.StartTime)
                {
                    return true;
                }
            }
            return false;
        }
    }
}