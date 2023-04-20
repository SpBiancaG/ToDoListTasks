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

    public class ToDoListViewModel : INotifyPropertyChanged
    {
        IToDoList _list;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ToDoItemViewModel> Items { get; private set; }

        public ToDoListViewModel(IToDoList list)
        {
            this._list = list;
            Items = new ObservableCollection<ToDoItemViewModel>(list.Items.Select(i => new ToDoItemViewModel(i)));
        }

        public string Name
        {
            get => _list.Name;
            set
            {
                _list.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public IToDoList List { get => _list; }

        public void Add(IToDoItem Task)
        {
            _list.Add(Task);
            Items.Add(new ToDoItemViewModel(Task));
        }

        public void Remove(ToDoItemViewModel selectedItem)
        {
            _list.Remove(selectedItem.Item);
            Items.Remove(selectedItem);
        }

        void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}