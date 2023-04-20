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

namespace MyToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            ApplicationViewModel? ViewModel = InitializeViewModel();
            MainWindow window = new MainWindow(ViewModel);
            app.Run(window);
            SerializeViewModel(ViewModel);

        }

        static ApplicationViewModel InitializeViewModel()
        {
            var ToDoLists = GetToDoLists();
            var viewModel = new ApplicationViewModel(ToDoLists, new Generator());
            return viewModel;
        }

        #region Serialization
        private static void SerializeViewModel(ApplicationViewModel viewModel)
        {
            List<IToDoList> toDoLists = viewModel.ToDoLists.Select(x => x.List).ToList();
            var json = Infrastructure.JsonSerializer.Serialize(toDoLists);
            Infrastructure.ResourceManager.WriteFile("ToDoLists", json);
        }

        static List<IToDoList> GetToDoLists()
        {
            var json = Infrastructure.ResourceManager.ReadFile("ToDoLists");
            var ToDoLists = Infrastructure.JsonSerializer.DeserealizeToDoLists(json);
            if (ToDoLists == null)
                ToDoLists = InitializeNewList();
            return ToDoLists;
        }
        #endregion

        static List<IToDoList> InitializeNewList()
        {
            return new List<IToDoList>()
            {
                new ToDoList()
                {
                    Name = "My first to do list!",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItem(){Text="My first task!"},
                    }
                }
            };
        }
    }
}
