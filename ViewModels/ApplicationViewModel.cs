namespace MyToDoList.ViewModels;
using MyToDoList.Infrastructure;
using MyToDoList.Models;
using MyToDoList.Models.Interfaces;

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
using MyToDoList.Views;

public class ApplicationViewModel : INotifyPropertyChanged
{
    #region Fields
    private readonly Generator Generator;
    private ToDoListViewModel selectedList;
    private ToDoItemViewModel selectedItem;
    private RelayCommand addItemCommand;
    private RelayCommand removeItemCommand;
    private RelayCommand addListCommand;
    private RelayCommand removeListCommand;
    #endregion

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ToDoListViewModel> ToDoLists { get; set; }

    public ApplicationViewModel(
        IEnumerable<IToDoList> todoLists,
        Generator generator)
    {
        Generator = generator;
        ToDoLists = new ObservableCollection<ToDoListViewModel>(todoLists.Select(l => new ToDoListViewModel(l)));
        if (ToDoLists.Count > 0)
            SelectedList = ToDoLists[0];
    }

    public ToDoListViewModel SelectedList
    {
        get => selectedList;
        set
        {
            selectedList = value;
            OnPropertyChanged("SelectedList");
            if (SelectedList?.Items.Count > 0)
                SelectedItem = SelectedList.Items[0];
        }
    }

    public ToDoItemViewModel SelectedItem
    {
        get => selectedItem;
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }

    #region //Commands
    public RelayCommand AddItemCommand
    {
        get
        {
            return addItemCommand ??
                (addItemCommand = new RelayCommand(obj =>
                {
                    var task = Generator.CreateItem();
                    SelectedList?.Add(task);
                }));
        }
    }

    public RelayCommand RemoveItemCommand
    {
        get
        {
            return removeItemCommand ??
                (removeItemCommand = new RelayCommand(obj =>
                {
                    SelectedList.Remove(SelectedItem);
                }));
        }
    }

    public RelayCommand AddListCommand
    {
        get
        {

            return addListCommand ??
                (addListCommand = new RelayCommand(obj =>
                {
                    ToDoLists.Add(new ToDoListViewModel(new ToDoList()));
                }));
        }
    }

    public RelayCommand RemoveListCommand
    {
        get
        {
            return removeListCommand ??
                (removeListCommand = new RelayCommand(obj =>
                {
                    ToDoLists.Remove(SelectedList);
                }));
        }
    }
    #endregion

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private ICommand aboutCommand;
    public ICommand AboutCommand
    {
        get
        {
            if (aboutCommand == null)
            {
                aboutCommand = new RelayCommand(About);
            }
            return aboutCommand;
        }
    }

    public void About(object param)
    {


        AboutWindow aboutWindow = new AboutWindow();
        aboutWindow.ShowDialog();

    }

}
