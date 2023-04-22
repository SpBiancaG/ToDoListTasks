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

namespace MyToDoList.Models.Interfaces
{
    public interface IToDoCategory
    {
        string Category { get; set; }
        List<IToDoList> Lists { get; set; }
        void Add(IToDoList list);
        void Remove(IToDoList selectedList);
    }
}
