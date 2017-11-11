using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProyectoFinal_Xamarin.Classes
{
    public class Professor
    {
        public string Uid { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        private IList<Asignatura> Asignaturas { get; set; } = new ObservableCollection<Asignatura>();
        private IList<Rubrica> Rubricas { get; set; } = new ObservableCollection<Rubrica>();
        private IList<Evaluacion> Evaluacioes { get; set; } = new ObservableCollection<Evaluacion>();

        public string FulName { get { return string.Format("{0} {1}", Name, LastName); } }

        public Professor(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            //Se crea el usuario y se guarda en la base de datos y se le setea el Uid
        }

    }
}
