using System;
using System.Windows.Controls;

using Module1.ViewModels;

namespace Module1.Views
{
    public partial class MasterView : UserControl
    {
        public MasterView(MasterViewModel viewModel)
        {
            InitializeComponent();

            // Set the ViewModel as this View's data context.
            this.DataContext = viewModel;
        }
    }
}
