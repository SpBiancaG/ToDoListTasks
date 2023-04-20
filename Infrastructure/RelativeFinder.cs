﻿
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
    public static class RelativeFinder
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent == null)
                return null;
            if (parent is T)
                return parent as T;
            return FindParent<T>(parent);
        }

        public static T FindParentByName<T>(DependencyObject child, string name) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent == null)
                return null;
            if (parent is T &&
                (parent as Control).Name == name)
                return parent as T;
            return FindParentByName<T>(parent, name);
        }

        public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = count - 1; i >= 0; i--)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                    return child as T;
                else child = FindChild<T>(child);
                if (child is T)
                    return child as T;
            }
            return null;
        }

        public static T FindChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T && (child as Control).Name == name)
                    return child as T;
                else child = FindChildByName<T>(child, name);
                if (child is T && (child as Control).Name == name)
                    return child as T;
            }
            return null;
        }
    }
}
