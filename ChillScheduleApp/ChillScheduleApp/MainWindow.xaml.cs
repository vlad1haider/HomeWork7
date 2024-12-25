using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ChillScheduleApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Activity> activities;

        public MainWindow()
        {
            InitializeComponent();
            activities = new ObservableCollection<Activity>();
            ActivitiesListBox.ItemsSource = activities;
        }

        private void AddActivityButton_Click(object sender, RoutedEventArgs e)
        {
            var addActivityWindow = new AddActivityWindow(activities);
            addActivityWindow.ShowDialog();
        }

        private void DeleteActivityButton_Click(object sender, RoutedEventArgs e)
        {
            if (ActivitiesListBox.SelectedItem is Activity selectedActivity)
            {
                activities.Remove(selectedActivity);
            }
        }
    }

    public class Activity
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return $"{Name} ({StartTime:HH:mm} - {EndTime:HH:mm})";
        }
    }
}