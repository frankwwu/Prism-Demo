using PrismScopedRegions.Infrastructure.Prism;
using System.Windows;

namespace PrismScopedRegions
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IView
    {
        public Shell(ShellViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
