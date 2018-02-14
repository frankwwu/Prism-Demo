using System;
using System.ComponentModel;
using Prism.Events;

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

    #endregion EventArgs

    #region Events

    public class InitialShellEvent : PubSubEvent<ModuleInfoArgs>
    {
    }

    public class ShellClosingEvent : PubSubEvent<ShellClosingEventArgs>
    {
    }

    #endregion Events
}
