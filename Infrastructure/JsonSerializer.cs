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

    public static class JsonSerializer
    {
        private static ISerializationBinder _binder = new TypeNameSerializationBinder();

        public static void SetSerializationBinder(ISerializationBinder binder)
        {
            _binder = binder;
        }

        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    SerializationBinder = _binder
                });
        }

        public static List<IToDoList>? DeserealizeToDoLists(string json)
        {
            return JsonConvert.DeserializeObject<List<IToDoList>>(json,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    SerializationBinder = _binder
                });
        }
    }

}