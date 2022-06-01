using Examen3.Repositories;
using Examen3.Repositorios;
using Examen3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen3
{
    public partial class App : Application
    {
        private static VehiculoRepositorio _VehiculosDb;
        public static VehiculoRepositorio VehiculosDb
        {
            get
            {
                if (_VehiculosDb == null)
                {
                    _VehiculosDb = new VehiculoRepositorio();
                }
                return _VehiculosDb;
            }
        }
        private static MarcaRepositorio _MarcasDb;
        public static MarcaRepositorio MarcasDb
        {
            get
            {
                if (_MarcasDb == null)
                {
                    _MarcasDb = new MarcaRepositorio();
                }
                return _MarcasDb;
            }
        }
        public App()
        {
            InitializeComponent();
            VehiculosDb.Init();
            MarcasDb.Init();
            MainPage = new NavigationPage(new PaginaPrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
