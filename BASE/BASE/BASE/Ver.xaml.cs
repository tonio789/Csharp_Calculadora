using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ver : ContentPage
    {
        public Ver()
        {
            InitializeComponent();
            ShowSaved();
        }

        private async void ShowSaved()
        {
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);

            // Crear una lista para guardar el txt leído
            List<LineaLeida> lineasLeidas = new List<LineaLeida>();

            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    String TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null)
                    {
                        // Añadir la línea leída a la lista
                        lineasLeidas.Add(new LineaLeida { Linea = TextoLeido });
                    }
                }
            }

            // Mostrar el contenido de la lista en el ListView
            ListViewLineasLeidas.ItemsSource = lineasLeidas;
        }
    }

    public class LineaLeida
    {
        public string Linea { get; set; }
    }



}
