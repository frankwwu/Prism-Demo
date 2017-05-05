using System.Windows.Controls;
using Module1.ViewModels;

namespace Module1.Views
{
    public partial class GreenView : UserControl
    {
        public GreenView(GreenViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
