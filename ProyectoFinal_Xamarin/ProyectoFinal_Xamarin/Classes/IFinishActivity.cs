using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal_Xamarin
{
    /// <summary>
    /// Interfaz para manejar el evento de finalizar una actividad
    /// y el retorno de datos
    /// </summary>
    /// <typeparam name="T">El tipo de dato que retorna el evento</typeparam>
    public interface IFinishActivity<T>
    {
        event EventHandler<T> FinishActivity;
    }
}
