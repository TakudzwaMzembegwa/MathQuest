using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        public void BtnSelect_Case(object sender, EventArgs e)
        { 
        }
    }
}