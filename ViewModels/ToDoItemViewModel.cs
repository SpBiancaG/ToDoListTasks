using MyToDoList.Infrastructure;
using MyToDoList.Models;
using MyToDoList.Models.Interfaces;
using MyToDoList.ViewModels;

using MyToDoList;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyToDoList.ViewModels
{

    public class ToDoItemViewModel : INotifyPropertyChanged
    {

        IToDoItem item;

        public bool IsCompleted
        {
            get => item.IsCompleted;
            set
            {
                item.IsCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }

        public IToDoItem Item { get => item; }

        public string Text
        {
            get => item.Text;
            set
            {
                item.Text = value;
                OnPropertyChanged("Text");
            }
        }

        public string Deadline
        {
            get => item.Deadline;
            set
            {
                item.Deadline = value;
                OnPropertyChanged("Deadline");
            }
        }

        public ToDoItemViewModel(IToDoItem item)
        {
            this.item = item;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}