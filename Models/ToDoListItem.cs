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

    public class ToDoItem : IToDoItem
    {
        public bool IsCompleted { get; set; } = false;
        public string Text { get; set; } = "New task";

        public string Deadline { get; set; } = null;
    }
}