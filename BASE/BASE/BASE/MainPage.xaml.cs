using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BASE
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnIr.Clicked += BtnIr_Clicked;
        }

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
            if ((txt_user.Text != "Admins" ) || (txt_pwd.Text != "1"))
            {
                DisplayAlert("ACCESO DENEGADO", "Ingrese los correctos credenciales", "Ok");
            }
            else
            {
                ((NavigationPage)this.Parent).PushAsync(new Menu(txt_user.Text));
            }
        }
    }
}
