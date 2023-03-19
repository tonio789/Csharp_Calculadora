using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.Profile;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu(string nombreUser)
        {
            InitializeComponent();
            lbluser.Text = nombreUser;
            btnSuma.Clicked += BtnSuma_Clicked;
            btnResta.Clicked += BtnResta_Clicked;
            btnMultiplicacion.Clicked += BtnMultiplicacion_Clicked;
            btnDivision.Clicked += BtnDivision_Clicked;
            btnSalir.Clicked += BtnSalir_Clicked;
            btnGuardado.Clicked += BtnGuardado_Clicked;
            btnEliminar.Clicked += BtnEliminar_Clicked;
            tbGuardar.Clicked += TbGuardar_Clicked;
            tbVer.Clicked += TbVer_Clicked;

            btnLimpiar.Clicked += BtnLimpiar_Clicked;
        }


        private void GuardarAppend(int a, string operacion, int b, int resultado)
        {
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            string mensaje = $"{a} {operacion} {b} = {resultado} \n";

            if (!File.Exists(rutaCompleta))
            {

                using (var escritor = File.CreateText(rutaCompleta))
                {

                    escritor.Write(mensaje);

                }
            } else
            {
                using (var escritor = File.AppendText(rutaCompleta))
                {

                    escritor.Write(mensaje);

                }
            }

            CleanEntries();
        }

        private void CleanEntries()
        {
            txt_dato1.Text = "";
            txt_dato2.Text = "";
        }

        private bool datosValidos()
        {
            if (string.IsNullOrWhiteSpace(txt_dato1.Text) || string.IsNullOrWhiteSpace(txt_dato2.Text))
            {
                DisplayAlert("CAMPOS VACIOS", "Por favor ingrese los datos en ambos campos", "Reintentar");
                return false;
            }
            if (double.TryParse(txt_dato1.Text, out double dato1) == false || double.TryParse(txt_dato2.Text, out double dato2) == false)
            {
                DisplayAlert("ERROR", "Los valores ingresados no son válidos", "Reintentar");
                return false;
            }
            return true;
        }


        private async void TbVer_Clicked(object sender, EventArgs e)
        {
            CleanEntries();
            await Navigation.PushAsync(new Ver());
        }

        private void TbGuardar_Clicked(object sender, EventArgs e)
        {
            CleanEntries();
        }

       private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
                lbl_txtGuardado.Text = "";
            }
            else
            {
                DisplayAlert("ERROR", "No hay archivos que eliminar", "Aceptar");
            }
        }




        private void BtnGuardado_Clicked(object sender, EventArgs e)
        {
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    String TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null)
                    {
                        lbl_txtGuardado.Text = TextoLeido;
                    }
                }
            }
        }



        private void BtnDivision_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt_dato1.Text) || string.IsNullOrWhiteSpace(txt_dato2.Text))
            {
                DisplayAlert("CAMPOS VACIOS", "Por favor ingrese los datos en ambos campos", "Reintentar");
                return;
            }

            int dato1, dato2;
            if (int.TryParse(txt_dato1.Text, out dato1) == false || int.TryParse(txt_dato2.Text, out dato2) == false)
            {
                DisplayAlert("ERROR", "Los valores ingresados no son válidos", "Reintentar");
                return;
            }

            if (dato2 == 0)
            {
                lbl_resultado.Text = "Error, no puede dividir entre 0";
                DisplayAlert("ERROR", "No puede dividir entre 0", "Ok");
                return;
            }

            int resultadoDivision = dato1 / dato2;
            lbl_resultado.Text = resultadoDivision.ToString();

        }

        private void BtnMultiplicacion_Clicked(object sender, EventArgs e)
        {
            if (datosValidos())
            {
                double resultadoMultiplicacion = Convert.ToDouble(txt_dato1.Text) * Convert.ToDouble(txt_dato2.Text);
                lbl_resultado.Text = resultadoMultiplicacion.ToString();
            }
        }

        private void BtnResta_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_dato1.Text) || string.IsNullOrWhiteSpace(txt_dato2.Text))
            {
                DisplayAlert("CAMPOS VACIOS", "Por favor ingrese los datos en ambos campos", "Reintentar");
                return;
            }

            int dato1, dato2;
            if (int.TryParse(txt_dato1.Text, out dato1) == false || int.TryParse(txt_dato2.Text, out dato2) == false)
            {
                DisplayAlert("ERROR", "Los valores ingresados no son válidos", "Reintentar");
                return;
            }


            int resultadoResta = dato1 - dato2;

            lbl_resultado.Text = resultadoResta.ToString();

        }

        private void BtnSuma_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_dato1.Text) || string.IsNullOrWhiteSpace(txt_dato2.Text))
            {
                DisplayAlert("CAMPOS VACIOS", "Por favor ingrese los datos en ambos campos", "Reintentar");
                return;
            }

            int dato1, dato2;
            if (int.TryParse(txt_dato1.Text, out dato1) == false || int.TryParse(txt_dato2.Text, out dato2) == false)
            {
                DisplayAlert("ERROR", "Los valores ingresados no son válidos", "Reintentar");
                return;
            }

            int resultadoSuma = dato1+ dato2;

            lbl_resultado.Text = resultadoSuma.ToString();

        }


        private void BtnSalir_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }


        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            CleanEntries();
        }


    }


}