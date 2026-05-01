using pk3DS.WinForms.Text;
using System;
using System.Windows.Forms;

#if !DEBUG
using System.Threading;
#endif

namespace pk3DS.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Initialize centralized string resources
            StringManager.Instance.Initialize("zh-CN");

#if !DEBUG
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += UIThreadException;

            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif

            // Run the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

#if !DEBUG
        // Handle the UI exceptions by showing a dialog box, and asking the user whether or not they wish to abort execution.
        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                ErrorWindow.ShowErrorDialog(Strings.Program_UnhandledException, t.Exception, true);
            }
            catch
            {
                try
                {
                    MessageBox.Show(Strings.Program_FatalWinFormsError, Strings.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var ex = (Exception)e.ExceptionObject;
                ErrorWindow.ShowErrorDialog(Strings.Program_FatalError, ex, false);
            }
            catch
            {
                try
                {
                    MessageBox.Show(Strings.Program_FatalNonUIError, Strings.Common_Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
#endif
    }
}
