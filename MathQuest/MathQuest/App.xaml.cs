using MathQuest.Services;
using MathQuest.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathQuest
{
    public partial class App : Application
    {
        private static QuestDatabase database;
        public static QuestDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                        QuestDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quest.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
