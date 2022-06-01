using Bogus;
using Examen3.Models;
using Examen3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen3.ViewModels
{
    public class PrincipalViewModel: BaseViewModel
        {
            public ObservableCollection<Vehiculo> Vehiculos { get; set; }
            public ICommand cmdAgregarVehiculo { get; set; }
            public ICommand cmdModificarVehiculo { get; set; }
            public PrincipalViewModel()
            {
                #region Propiedades
                Vehiculos = new ObservableCollection<Vehiculo>();
                #endregion
                #region Comandos
                cmdAgregarVehiculo = new Command(() => cmdAgregarVehiculoMetodo());
                cmdModificarVehiculo = new Command<Vehiculo>((item) => cmdModificarVehiculoMetodo(item));
                #endregion

            }
            #region Metodos
            private async void cmdAgregarPeliculaMetodo(Vehiculo vehiculo)
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetallesVehiculo(vehiculo));
            }
            private async void cmdAgregarVehiculoMetodo()
            {
                Vehiculo vehiculo= new Faker<Vehiculo>()
                    .RuleFor(c => c.Modelo, f => f.Commerce.ProductName())
                    .RuleFor(c => c.Ano, f => f.Commerce.ProductDescription());
                vehiculo.Marca = new Faker<Marca>()
                    .RuleFor(c => c.Nombre, f => f.Company.CompanyName())
                    .RuleFor(c => c.Logo, f => f.Internet.Avatar());
                await App.Current.MainPage.Navigation.PushAsync(new DetallesVehiculo(vehiculo));
            }
            private async void cmdModificarVehiculoMetodo(Vehiculo vehiculo)
            {
                await App.Current.MainPage.Navigation.PushAsync(new DetallesVehiculo(vehiculo));
            }
            public void GetAll()
            {
                if (Vehiculos != null)
                {
                Vehiculos.Clear();
                    App.VehiculosDb.GetAll().ForEach(item => Vehiculos.Add(item));
                }
                else
                {
                    Vehiculos = new ObservableCollection<Vehiculo>(App.VehiculosDb.GetAll());
                }
                OnPropertyChanged();
            }
            #endregion
        }
}
