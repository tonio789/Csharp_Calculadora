using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BASE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {

        //Creado por Antonio Alvarez y Jeremy Garcia
        public Menu(string nombreUser)
        {
            InitializeComponent();
            lbluser.Text = nombreUser;
            btnSuma.Clicked += BtnSuma_Clicked;
            btnResta.Clicked += BtnResta_Clicked;
            btnMultiplicacion.Clicked += BtnMultiplicacion_Clicked;
            btnDivision.Clicked += BtnDivision_Clicked;
            btnSalir.Clicked += BtnSalir_Clicked;
            btnEliminar.Clicked += BtnEliminar_Clicked;
            tbGuardar.Clicked += TbGuardar_Clicked;
            tbVer.Clicked += TbVer_Clicked;
            btnLimpiar.Clicked += BtnLimpiar_Clicked;
        }

        double a = 0;
        string operacion = "";
        double b = 0;
        double r = 0;

        private void guardarAppend()
        {
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            string mensaje = $"{this.a} {this.operacion} {this.b} = {this.r} \n";

            if (!File.Exists(rutaCompleta))
            {
                using (var escritor = File.CreateText(rutaCompleta))
                {

                    escritor.Write(mensaje);
                }
            }
            else
            {
                using (var escritor = File.AppendText(rutaCompleta))
                {
                    escritor.Write(mensaje);
                }
            }

            cleanEntries();
        }
        private void cleanEntries()
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
        private void borrarTXT()
        {
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
        }

        private void calculo(string operacion)
        {

            if (datosValidos())
            {
                double a = Convert.ToDouble(txt_dato1.Text);
                double b = Convert.ToDouble(txt_dato2.Text);
                double r = 0;
                try
                {
                    switch (operacion)
                    {
                        case "*":
                            r = a * b;
                            break;
                        case "/":
                            r = a / b;
                            break;
                        case "+":
                            r = a + b;
                            break;
                        case "-":
                            r = a - b;
                            break;
                    }
                    this.a = a;
                    this.b = b;
                    this.r = r;
                    this.operacion = operacion;
                    lbl_resultado.Text = $"{this.a} {this.operacion} {this.b} = {this.r} \n";
                    cleanEntries();
                }
                catch
                {
                    DisplayAlert("ERROR", "Resultado indefinido", "Ok");
                }
            }
        }

        //Botones Funcionales
        private void BtnDivision_Clicked(object sender, EventArgs e)
        {
            calculo("/");
        }
        private void BtnMultiplicacion_Clicked(object sender, EventArgs e)
        {
            calculo("*");
        }
        private void BtnResta_Clicked(object sender, EventArgs e)
        {
            calculo("-");
        }
        private void BtnSuma_Clicked(object sender, EventArgs e)
        {
            calculo("+");
        }


        //Toolbar
        private async void TbVer_Clicked(object sender, EventArgs e)
        {
            cleanEntries();
            await Navigation.PushAsync(new Ver());
        }
        private void TbGuardar_Clicked(object sender, EventArgs e)
        {
            guardarAppend();
        }

        //Otros Botones
        private void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            borrarTXT();
        }
        private void BtnSalir_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            cleanEntries();
        }
    }
}