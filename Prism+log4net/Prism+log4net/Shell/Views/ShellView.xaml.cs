using System;
using System.Windows;
using System.Windows.Controls;

using Shell.ViewModels;

namespace Shell.Views
{
    public partial class ShellView : Window
    {
        public ShellView(ShellViewModel viewModel)
        {
            InitializeComponent();

            // Set the ViewModel as this View's data context.
            this.DataContext = viewModel;
        }
    }
}
