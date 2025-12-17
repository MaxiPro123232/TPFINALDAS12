using TechStore.Vistas;

namespace Vista
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        // Punto de entrada principal de la aplicación. Inicializa la configuración y muestra el formulario principal.
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
        }
    }
}