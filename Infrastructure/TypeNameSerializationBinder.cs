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
    class TypeNameSerializationBinder : ISerializationBinder
    {
        public void BindToName(Type serializedType,
                               out string? assemblyName,
                               out string? typeName)
        {
            assemblyName = null;
            typeName = serializedType.AssemblyQualifiedName;
        }

        public Type? BindToType(string assemblyName, string typeName)
        {
            var resolvedTypeName = string.Format("{0}, {1}", typeName, assemblyName);
            return Type.GetType(resolvedTypeName, true);
        }
    }
}