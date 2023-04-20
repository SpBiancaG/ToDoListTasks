﻿using MyToDoList.Infrastructure;
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
namespace MyToDoList.Models.Interfaces
{

    public interface IToDoList
    {
        string Name { get; set; }
        List<IToDoItem> Items { get; set; }
        void Add(IToDoItem Task);
        void Remove(IToDoItem selectedItem);
    }
}