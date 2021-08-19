using Autofac;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    static class Program
    {
        public static IContainer Container;

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container = Configure();
            Application.Run(new Form1(Container.Resolve<IProductRepository>()));
        }

        /// <summary>
        /// Settings Dependency Injection
        /// </summary>
        /// <returns></returns>
        static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<Form1>();
            return builder.Build();
        }
    }
}
