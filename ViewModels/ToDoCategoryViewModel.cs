using MyToDoList.Infrastructure;
using MyToDoList.Models;
using MyToDoList.Models.Interfaces;
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
    public class ToDoCategoryViewModel : INotifyPropertyChanged
    {
        private IToDoCategory _category;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ToDoListViewModel> Lists { get; private set; }

        public ToDoCategoryViewModel(IToDoCategory category)
        {
            this._category = category;
            Lists = new ObservableCollection<ToDoListViewModel>(category.Lists.Select(l => new ToDoListViewModel(l)));
        }

        public string Category
        {
            get => _category.Category;
            set
            {
                _category.Category = value;
                OnPropertyChanged("Category");
            }
        }

        public IToDoCategory CategoryModel { get => _category; }

        public void Add(IToDoList list)
        {
            _category.Add(list);
            Lists.Add(new ToDoListViewModel(list));
        }

        public void Remove(ToDoListViewModel selectedList)
        {
            _category.Remove(selectedList.List);
            Lists.Remove(selectedList);
        }

        void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
