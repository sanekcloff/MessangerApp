﻿using ApplicationData.Core.Context;
using Messanger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messanger.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Window
    {
        AuthorizationViewModel viewModel;
        public AuthorizationView()
        {
            InitializeComponent();
            viewModel = new AuthorizationViewModel(new AppDbContext());
            DataContext = viewModel;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RegistrateUser();
        }
    }
}