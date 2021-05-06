using DNI.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebTokenGenerator.Shared.Abstractions;

namespace WebTokenGenerator.WinApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterServiceDependencies(new[] { typeof(Program).Assembly, }, 
                ServiceLifetime.Singleton, new[] { "Form" });
            var services = serviceCollection.BuildServiceProvider();

            var form1 = services.GetRequiredService<IMainForm>();
            Application.Run(form1 as Form);
        }
    }
}
