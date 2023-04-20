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


namespace MyToDoList.Models
{

    public class ToDoList : IToDoList
    {
        public List<IToDoItem> Items { get; set; } = new List<IToDoItem>();
        public string Name { get; set; } = "List";

        public void Add(IToDoItem Task)
        {
            Items.Add(Task);
        }

        public void Remove(IToDoItem selectedItem)
        {
            Items.Remove(selectedItem);
        }
    }
}