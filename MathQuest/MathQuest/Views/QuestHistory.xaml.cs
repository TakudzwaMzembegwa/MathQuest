using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathQuest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestHistory : ContentPage
    {
        public QuestHistory()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();


            collectionView.ItemsSource = await App.Database.GetQuestsAsync();
        }
    }
}