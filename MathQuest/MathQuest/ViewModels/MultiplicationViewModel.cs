using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MathQuest.ViewModels
{
    public class MultiplicationViewModel : INotifyPropertyChanged
    {
        const int counter = 10;
        public static int max = 0;
        string entry = "0";
        string num1 = "0";
        string num2 = "0";
        Random rand = new Random();
       
        public event PropertyChangedEventHandler PropertyChanged;

        public MultiplicationViewModel()
        {
            Num1 = rand.Next(max + 1).ToString();
            Num2 = rand.Next(max + 1).ToString();

            ClearCommand = new Command(
                execute: () =>
                {
                    Entry = "0";
                    RefreshCanExecutes();
                });
            BackspaceCommand = new Command(
           execute: () =>
           {
               Entry = Entry.Substring(0, Entry.Length - 1);
               if (Entry == "")
               {
                   Entry = "0";
               }
               RefreshCanExecutes();
           },
           canExecute: () =>
           {
               return Entry.Length > 1 || Entry != "0";
           });

            DigitCommand = new Command<string>(
            execute: (string arg) =>
            {
                Entry += arg;
                if (Entry.StartsWith("0") && !Entry.StartsWith("0."))
                {
                    Entry = Entry.Substring(1);
                }
                RefreshCanExecutes();
            },
            canExecute: (string arg) =>
            {
                return !(arg == "." && Entry.Contains("."));
            });

            NextCommand = new Command(execute: () =>
            {
                Num1 = rand.Next(max + 1).ToString();
                Num2 = rand.Next(max + 1).ToString();

                RefreshCanExecutes();
            });
        }
        public string Entry
        {
            private set
            {
                if (entry != value)
                {
                    entry = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
                }
            }
            get
            {
                return entry;
            }
        }

        public string Num1
        {
            private set
            {
                if (num1 != value)
                {
                    num1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Num1"));
                }
            }
            get
            {
                return num1;
            }
        }

        public string Num2
        {
            private set
            {
                if (num2 != value)
                {
                    num2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Num2"));
                }
            }
            get
            {
                return num2;
            }
        }

        public ICommand ClearCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }

        public ICommand DigitCommand { private set; get; }
        public Command NextCommand { get; private set; }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)DigitCommand).ChangeCanExecute();
        }
    }
}