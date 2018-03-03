using System.Linq;
using System.Windows;

namespace MultiShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("{0}", e.Exception.GetBaseException().Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if ((e.Args != null) && (e.Args.Count() > 0))
            {
                string flag = e.Args.FirstOrDefault();
                if ((flag.Count() > 0) && (flag[0].Equals('-')))
                {
                    flag = flag.Remove(0, 1);
                }
                Bootstrapper bs = new Bootstrapper(flag);
                bs.Run();
            }
            else
            {
                Bootstrapper bs = new Bootstrapper();
                bs.Run();
            }
        }
    }
}
