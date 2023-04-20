using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApplicationViewModel applicationViewModel)
        {
            InitializeComponent();
            this.DataContext = applicationViewModel;
        }

        private void EditTextBoxLostFocus(object sender, RoutedEventArgs e)
        {

            var parent = RelativeFinder.FindParent<ItemsControl>(sender as TextBox);
            var button = RelativeFinder.FindChildByName<ToggleButton>(parent, "EditButton");
            button.IsChecked = false;
        }

        private void SelectAllText(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.SelectAll();
        }

        private void LoseFocusOnEnterKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                EditTextBoxLostFocus(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}