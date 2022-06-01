using Examen3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen3.ViewModels
{
    public class DetallesVehiculoViewModel
    {
        public Vehiculo Vehiculo { get; set; }


        public ICommand cmdAgregarVehiculo { get; set; }
        public DetallesVehiculoViewModel(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
            cmdAgregarVehiculo = new Command<Vehiculo>((item) => cmdAgregarVehiculoMetodo(item));
        }
        private async void cmdAgregarVehiculoMetodo(Vehiculo vehiculo)
        {
            App.VehiculosDb.InsertOrUpdate(vehiculo);
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
