using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoFinal_Xamarin;
using ProyectoFinal_Xamarin.Classes;
using Firebase.Xamarin.Auth;
using System.Diagnostics;

namespace ProyectoFinal_Xamarin
{
	public partial class LoginPage : ContentPage
	{
        public static FirebaseAuth auth;

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
            registerPage.FinishActivity += OnFinishRegisterActivity;
            Navigation.PushAsync(registerPage);
        }

        /// <summary>
        /// Callback que se ejecuta cuando ocurre el evento FinishActivity de la pagina de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">La ReturnInfo que contiene el result y el return data del register page que contiene
        /// el professor creado y su contraseña.</param>
        private async void OnFinishRegisterActivity(object sender, ReturnInfo<RegisterPage.ReturnData> e)
        {
            if (e.Result == ReturnResult.Successful)//Todo bien
            {
                RegisterPage.ReturnData data = e.Data;
                try
                {
                    auth = await FirebaseHelper.authProvider.CreateUserWithEmailAndPasswordAsync(data.ProfessorInfo.Email, data.Password);
                    //guardamos el usuario en la base de datos
                    await data.ProfessorInfo.SaveThisUserOnDB();
                    ShowHomePage();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "That email exist already", "OK");
                    //throw ex;
                }
            }
        }

        /// <summary>
        /// Evento del click del boton LogIn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void LogIn(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(entryEmail.Text) && !String.IsNullOrEmpty(entryPassword.Text))
            {
                try
                {
                    auth = await FirebaseHelper.authProvider.SignInWithEmailAndPasswordAsync(entryEmail.Text, entryPassword.Text);
                    ShowHomePage();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Credentials are not registered in data base", "OK");
                    //throw ex;
                }
            }
            else
            {
                await DisplayAlert("Error", "Email or password field is empty", "OK");
            }
        }

        /// <summary>
        /// Muestra la ventana principal y la coloca como la main page de la aplicacion
        /// </summary>
        private void ShowHomePage()
        {
            //Toda la logica del login
            Debug.WriteLine("FederatedID: " + auth.User.FederatedId);
            Debug.WriteLine("Token: " + auth.FirebaseToken);
            Debug.WriteLine("Local ID: "+auth.User.LocalId);
            Debug.WriteLine("email: " + auth.User.Email);
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
    }
}
