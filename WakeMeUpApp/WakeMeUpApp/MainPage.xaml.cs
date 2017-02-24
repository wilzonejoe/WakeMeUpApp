using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WakeMeUpApp.API;
using WakeMeUpApp.SQL;
using Xamarin.Forms;

namespace WakeMeUpApp
{
    public partial class MainPage : ContentPage
    {
        private Time needToGo;

        public MainPage()
        {
            InitializeComponent();

            SampleDatabase();
        }

        public void SampleDatabase()
        {
            needToGo = new Time()
            {
                Hour = 10,
                Minute = 0,
                Second = 0
            };
            DatabaseHelper.Database.SaveItemAsync(new Time()
            {
                Hour = 12,
                Minute = 0,
                Second = 0,
            });
            List<Time> times = DatabaseHelper.Database.GetItemsAsync().Result;
            Time time = times.First();
            MainLabel.Text = time.ToString();
            for (int i = 0; i < times.Count; i++)
            {
                needToGo.Subtract(times[i]);
            }
            MainLabel2.Text = needToGo.ToString();
            TimeList.ItemsSource = times;
        }

        private async void AddButton_OnClicked(object sender, EventArgs e)
        {
            Time time1 = DatabaseHelper.Database.GetItemsAsync().Result.First();
            Time time2 = new Time()
            {
                Hour = 1,
                Minute = 0,
                Second = 0
            };

            time1.Add(time2);
            await DatabaseHelper.Database.SaveItemAsync(time1);
            Time time = DatabaseHelper.Database.GetItemsAsync().Result.First();
            MainLabel.Text = time.ToString();
        }


        private async void SubtractButton_OnClicked(object sender, EventArgs e)
        {
            Time time1 = DatabaseHelper.Database.GetItemsAsync().Result.First();
            Time time2 = new Time()
            {
                Hour = 1,
                Minute = 0,
                Second = 0
            };
            time1.Subtract(time2);
            await DatabaseHelper.Database.SaveItemAsync(time1);
            Time time = DatabaseHelper.Database.GetItemsAsync().Result.First();
            MainLabel.Text = time.ToString();
        }


        private async void PlusButton_OnClicked(object sender, EventArgs e)
        {
            Time time1 = new Time()
            {
                Hour = 1,
                Minute = 0,
                Second = 0
            };
            await DatabaseHelper.Database.SaveItemAsync(time1);

            List<Time> time = DatabaseHelper.Database.GetItemsAsync().Result;
            for (int i = 0; i < time.Count; i++)
            {
                needToGo.Subtract(time[i]);
            }
            MainLabel2.Text = needToGo.ToString();
            TimeList.ItemsSource = time;
        }
    }
}