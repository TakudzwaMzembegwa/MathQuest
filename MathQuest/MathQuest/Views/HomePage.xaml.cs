using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MathQuest.ViewModels;

namespace MathQuest.Views
{
    public partial class HomePage : ContentPage
    {
        public string difficultyLevel;
        public HomePage()
        {
            InitializeComponent();
        }

        /*
       * RadioButton CheckChange Event Handler
       */
        void RadioSelected(object sender, CheckedChangedEventArgs e)
        {
            difficultyLevel = (sender as RadioButton).Content.ToString();
        }

        async void OnSubmit(object sender, EventArgs e)
        {
            switch (difficultyLevel)
            {
                case "Difficult":
                    MultiplicationViewModel.max = 99;
                    break;
                case "Intermediate":
                    MultiplicationViewModel.max = 12;
                    break;
                default:
                    MultiplicationViewModel.max = 5;
                    break;
            }
            await Navigation.PushAsync(new MultiplicationPage());
        }
        async void OnView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuestHistory());
        }
    }
}