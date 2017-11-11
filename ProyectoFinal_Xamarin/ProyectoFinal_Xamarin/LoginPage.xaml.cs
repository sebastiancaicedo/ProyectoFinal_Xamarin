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
            InitFirebase();
		}

        private void InitFirebase()
        {
            
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
        async private void OnFinishRegister(object sender, ReturnInfo<RegisterPage.ReturnData> e)
        {
            //Todo bien
            if (e.Result == ReturnResult.Succesful)
            {
                RegisterPage.ReturnData data = e.Data;
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDBHelper.APP_API_KEY));
                auth = await authProvider.CreateUserWithEmailAndPasswordAsync(data.ProfessorInfo.Email, data.Password);
                LogIn();
            }
        }

        async public void OnLoginButtonClick(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDBHelper.APP_API_KEY));
            auth = await authProvider.SignInWithEmailAndPasswordAsync(entryEmail.Text, entryPassword.Text);
            LogIn();
        }

        async private void LogIn()
        {
            //Toda la logica del login
            Debug.WriteLine("FederatedID: " + auth.User.FederatedId);
            Debug.WriteLine("Token: " + auth.FirebaseToken);
            Debug.WriteLine("Local ID: "+auth.User.LocalId);
            Debug.WriteLine("email: " + auth.User.Email);
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}
