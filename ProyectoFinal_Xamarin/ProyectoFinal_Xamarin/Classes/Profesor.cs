using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_Xamarin.Classes
{
    public class Profesor
    {
        public string Uid { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public string FulName { get { return string.Format("{0} {1}", Name, LastName); } }

        public Profesor(string name, string lastName, string email, string password)
        {
            //Se crea el usuario y se guarda en la base de datos y se le setea el Uid
        }

    }
}
