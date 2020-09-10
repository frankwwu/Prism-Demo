# Prism + log4net

The motivation of this update is to migrate Prism from v6.x to v7.x. Since the <code>Bootstrapper</code> is deprecated in Prism v7.x, and the <code>ILoggerFacade</code> interface is going away in v8.0, log4net is treated as a regular object, or as a registered instance via <code>IContainerRegistry</code>.

+ In Shell project, App.xaml.cs demos how to configure log4net declared in app.config.

+ Module1 project shows how to create an instance of log in the ViewModel.

+ Module2 project demos how to register a log with <code>IContainerRegistry</code> and consume the instance in the ViewModel.

Problem: Shell project is able to log with line number. However, the line number values in the module’s log messages are always 0. A bug? 



