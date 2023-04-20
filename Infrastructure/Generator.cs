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

namespace MyToDoList.Infrastructure
{

    public class Generator
    {
        private Func<IToDoItem> generateToDoItem = () => new ToDoItem();
        private Func<IToDoList> generateToDoList = () => new ToDoList();
        public Generator(Func<IToDoItem>? generateToDoItem = null, Func<IToDoList>? generateToDoList = null)
        {
            if (generateToDoItem != null)
                this.generateToDoItem = generateToDoItem;
            if (generateToDoList != null)
                this.generateToDoList = generateToDoList;
        }
        public IToDoItem CreateItem() => generateToDoItem.Invoke();
        public IToDoList CreateList() => generateToDoList.Invoke();
    }

}