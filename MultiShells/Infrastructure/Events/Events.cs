using Prism.Events;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Infrastructure.Events
{
    #region EventArgs

    public class ModuleInfoArgs : EventArgs
    {
        public string ModuleInstanceID { get; set; }
        public string ShellCaption { get; set; }
    }

    public class ShellClosingEventArgs : EventArgs
    {
        public string ModuleInstanceID { get; set; }
        public CancelEventArgs EventArgs { get; set; }
    }

    public class IconChangedEventArgs : EventArgs
    {
        public string ModuleInstanceID { get; set; }
        public ImageSource Icon { get; set; }
    }

    #endregion EventArgs

    #region Events

    public class InitialShellEvent : PubSubEvent<ModuleInfoArgs>
    {
    }

    public class ShellClosingEvent : PubSubEvent<ShellClosingEventArgs>
    {
    }

    public class IconChangedEvent : PubSubEvent<IconChangedEventArgs>
    {
    }

    #endregion Events
}
