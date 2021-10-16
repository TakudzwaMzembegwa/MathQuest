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
        public static int max = 5;
        public int totalCorrect = 0;
        const int maxRuns = 10;
        int counter = 0;
        string feedback = "";
        string feedbackColor = "";
        string symbol = "";
        string currentProgress = "0";
        string entry = "0";
        string num1 = "0";
        string num2 = "0";
        Random rand = new Random();
       
        public event PropertyChangedEventHandler PropertyChanged;

        public MultiplicationViewModel()
        {
            Num1 = rand.Next(max + 1).ToString();
            Num2 = rand.Next(max + 1).ToString();
            Feedback = "MathQuest";
            FeedbackColor = "#24a0ed";
            Symbol = "⏭";
            CurrentProgress = "0.1";

            CheckCommand = new Command(
                execute: () =>
                {
                
                    if (!feedback.Equals("MathQuest"))
                    {
                        return;
                    }
                    else if (entry.Equals((int.Parse(num1) * int.Parse(num2)).ToString())) {
                        Feedback = "Correct";
                        FeedbackColor = "#0F0";
                        totalCorrect++;
                    }
                    else
                    {
                        Feedback = "Wrong\nAnswer is: " + (int.Parse(num1) * int.Parse(num2)).ToString();
                        FeedbackColor = "#FF0000";
                    }
                    counter++;
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
                counter++;
                if (counter == 9)
                {
                    Symbol = "⟲";
                }
                else if (counter > 9)
                {
                    counter = 0;
                    Symbol = "⏭";
                }
                Num1 = rand.Next(max + 1).ToString();
                Num2 = rand.Next(max + 1).ToString();
                Feedback = "MathQuest";
                FeedbackColor = "#24a0ed";
                CurrentProgress = ((counter + 1) / (maxRuns * 1.0)).ToString();
                Entry = "0";
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

        public string CurrentProgress
        {
            private set
            {
                if (currentProgress != value)
                {
                    currentProgress = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentProgress"));
                }
            }
            get
            {
                return currentProgress;
            }
        }
        public string Feedback
        {
            private set
            {
                if (feedback != value)
                {
                    feedback = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Feedback"));
                }
            }
            get
            {
                return feedback;
            }
        }
        public string FeedbackColor
        {
            private set
            {
                if (feedbackColor != value)
                {
                    feedbackColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FeedbackColor"));
                }
            }
            get
            {
                return feedbackColor;
            }
        }
        public string Symbol
        {
            private set
            {
                if (symbol != value)
                {
                    symbol = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Symbol"));
                }
            }
            get
            {
                return symbol;
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

        public Command CheckCommand { get; private set; }

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