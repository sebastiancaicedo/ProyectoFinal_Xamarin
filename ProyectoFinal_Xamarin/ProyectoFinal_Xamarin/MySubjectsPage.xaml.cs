﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MySubjectsPage : TabbedPage
	{
		public MySubjectsPage ()
		{
            Title = "My Subjects";
			InitializeComponent ();
		}
	}
}