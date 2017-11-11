using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoFinal_Xamarin.Classes;

namespace ProyectoFinal_Xamarin
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage, IFinishActivity<RegisterPage.ReturnData>
	{

        public event EventHandler<ReturnInfo<ReturnData>> FinishActivity;

        public RegisterPage ()
		{
            Title = "Register";
			InitializeComponent ();
		}

        /// <summary>
        /// Evento del click del boton register
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Register(object sender, EventArgs e)
        {
            string name = entryName.Text;
            string lastName = entryLastName.Text;
            string email = entryEmail.Text;
            string password = entryPassword.Text;
            string confirmPass = entryConfirmPassword.Text;

            if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(lastName) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(confirmPass)){
                if(password == confirmPass)
                {
                    Professor professor = new Professor(name, lastName, email);
                    Navigation.PopAsync();
                    FinishActivity(this, new ReturnInfo<ReturnData>(ReturnResult.Succesful, new ReturnData(professor, password)));
                }
                else
                {
                    DisplayAlert("Error", "Confirmation password doesn't matches", "OK");
                }
            }
            else
            { 
                DisplayAlert("Error", "All fields must be full", "OK");
            }
        }

        public struct ReturnData
        {
            public Professor ProfessorInfo { get; private set; }
            public string Password { get; private set; }

            public ReturnData(Professor professor, string password)
            {
                ProfessorInfo = professor;
                Password = password;
            }
        }
    }
}