using System.Windows.Interactivity;

namespace MultiShell.Behaviors
{
    public class ShellBehavior : Behavior<Shell>
    {
        protected override void OnAttached()
        {           
            AssociatedObject.Closing += OnClosing;
        }

        protected override void OnDetaching()
        {           
            AssociatedObject.Closing -= OnClosing;
        }

        void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Shell shell = sender as Shell;
            ShellViewModel vm = shell.DataContext as ShellViewModel;            vm.ShellClosingCommand.Execute(e);
        }
    }
}
