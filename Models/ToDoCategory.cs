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

using System.Collections.Generic;

namespace MyToDoList.Models
{
    public class ToDoCategory : IToDoCategory
    {
        public string Category { get; set; }
        public List<IToDoList> Lists { get; set; }

        public ToDoCategory()
        {
            Lists = new List<IToDoList>();
        }

        public void Add(IToDoList list)
        {
            Lists.Add(list);
        }

        public void Remove(IToDoList selectedList)
        {
            Lists.Remove(selectedList);
        }
    }
}
