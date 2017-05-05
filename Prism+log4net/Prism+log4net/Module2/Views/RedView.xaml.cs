using System.Windows.Controls;
using Module2.ViewModels;

namespace Module2.Views
{
    public partial class RedView : UserControl
    {
        public RedView(RedViewModel viewModel)
        {
            InitializeComponent();         
            this.DataContext = viewModel;
        }
    }
}
