using Examen3.Models;
using Examen3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesVehiculo : ContentPage
    {
        public DetallesVehiculo(Vehiculo vehiculo)
        {
            InitializeComponent();
            BindingContext = new DetallesVehiculoViewModel(vehiculo);
        }
    }
}