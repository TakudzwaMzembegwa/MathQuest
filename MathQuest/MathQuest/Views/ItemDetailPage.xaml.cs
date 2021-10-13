using MathQuest.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MathQuest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}