using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoFinal_Xamarin;
using ProyectoFinal_Xamarin.Classes;

namespace ProyectoFinal_Xamarin
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
            Title = "Sign In";
			InitializeComponent();
		}

        /// <summary>
        /// Evento del click del boton show register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowRegisterPage(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.FinishActivity += OnFinishRegister;
            Navigation.PushAsync(registerPage);
        }

        /// <summary>
        /// Callback que se ejecuta cuando ocurre el evento FinishActivity de la pagina de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFinishRegister(object sender, ReturnInfo<Profesor> e)
        {
            //Todo bien
            if(e.Result == ReturnResult.Succesful)
            {
                Profesor profesor = e.Data;
                LogIn();
            }
        }

        private void LogIn()
        {
            //Toda la logica del login
        }
    }
}
