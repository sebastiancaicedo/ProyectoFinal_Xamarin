using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyRubricsPage : ContentPage
	{
		public MyRubricsPage ()
		{
            Title = "My Rubrics";
			InitializeComponent ();
		}

        public void CreateNewRubric(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DePrueba());
        }

    }
}