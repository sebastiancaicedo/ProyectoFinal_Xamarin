using Firebase.Xamarin.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Firebase.Xamarin.Database;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProyectoFinal_Xamarin.Classes
{
    public class Professor
    {
        //El Id se maneja con el UID que se genera cuando se crea un usuario para autenticacion, se guarda con ese mismo
        //public string Uid { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        private IList<Asignatura> Subjects { get; set; } = new ObservableCollection<Asignatura>();
        private IList<Rubrica> Rubrics { get; set; } = new ObservableCollection<Rubrica>();
        private IList<Evaluacion> Evaluations { get; set; } = new ObservableCollection<Evaluacion>();

        public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }

        public Professor(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public async Task<bool> SaveThisUserOnDB()
        {
            try
            {
                await FirebaseHelper.firebaseDBClient
                .Child("professors")//tabla profesores
                .Child(LoginPage.auth.User.LocalId)//se usa el id creado por la autenticacion como key tambien
                //.WithAuth(token)
                .PutAsync<Professor>(this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

    }
}
