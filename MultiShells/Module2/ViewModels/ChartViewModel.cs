using Infrastructure.Events;
using Infrastructure.MultiShell;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Module2.ViewModels
{
    public class ChartViewModel : BindableBase
    {
        private readonly string _moduleInstanceID;
        private readonly IEventAggregator _eventAggregator;
        private readonly IModuleCatalog _catalog;
        private readonly IShellService _shellService;
        private static Random random = new Random();

        public ChartViewModel(IEventAggregator eventAggregator, IModuleCatalog catalog, IShellService shellService)
        {
            _moduleInstanceID = Guid.NewGuid().ToString();
            _eventAggregator = eventAggregator;
            _catalog = catalog;
            _shellService = shellService;

            // Events      
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            ModuleInfoArgs args = new ModuleInfoArgs() { ShellCaption = "Module 2", ModuleInstanceID = _moduleInstanceID };
            _eventAggregator.GetEvent<InitialShellEvent>().Publish(args);
            _eventAggregator.GetEvent<ShellClosingEvent>().Subscribe(OnShellClosing);

            IconChangedEventArgs iconArgs = new IconChangedEventArgs();
            iconArgs.ModuleInstanceID = _moduleInstanceID;
            iconArgs.Icon = BitmapFrame.Create(new Uri(@"pack://application:,,,/Module2;component/Module2.png"));
            _eventAggregator.GetEvent<IconChangedEvent>().Publish(iconArgs);

            // Commands
            StartMenuCommand = new DelegateCommand<object>(StartMenu);
            Time = DateTime.Now.ToLongTimeString();
            byte[] rgb = new byte[3];
            random.NextBytes(rgb);
            Color color = Color.FromRgb(rgb[0], rgb[1], rgb[2]);
            Foreground = new SolidColorBrush(color);

        }

        #region Public Properties

        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; RaisePropertyChanged(); }
        }

        private Brush _foreground;

        public Brush Foreground
        {
            get { return _foreground; }
            set { _foreground = value; RaisePropertyChanged(); }
        }

        #endregion Public Properties

        private void OnShellClosing(ShellClosingEventArgs args)
        {
        }

        #region StartMenuCommand

        public DelegateCommand<object> StartMenuCommand { get; private set; }

        private void StartMenu(object param)
        {
            Button btn = param as Button;
            if (btn != null)
            {
                Infrastructure.StartMenu.StartMenu start = new Infrastructure.StartMenu.StartMenu(_shellService);
                start.PlacementTarget = btn;
                start.IsMenuOpen = true;
            }
        }

        #endregion StartMenuCommand
    }
}
