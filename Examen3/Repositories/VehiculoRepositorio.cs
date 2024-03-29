﻿using Examen3.Constants;
using Examen3.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Examen3.Repositorios
{
    public class VehiculoRepositorio
    {
        SQLiteConnection connection;
        public VehiculoRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<Vehiculo>();
        }
        public void Init()
        {
            connection.CreateTable<Vehiculo>();
        }
        public void InsertOrUpdate(Vehiculo vehiculo)
        {
            if (vehiculo.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {vehiculo.Id}");
                connection.InsertWithChildren(vehiculo);
                Debug.WriteLine($"Id despues de registrar {vehiculo.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {vehiculo.Id}");
                connection.Update(vehiculo);
                App.MarcasDb.InsertOrUpdate(vehiculo.Marca);
                Debug.WriteLine($"Id despues de actualizar {vehiculo.Id}");
            }
        }
        public Vehiculo GetById(int Id)
        {
            return connection.Table<Vehiculo>().FirstOrDefault(item => item.Id == Id);
        }
        public List<Vehiculo> GetAll()
        {
            return connection.GetAllWithChildren<Vehiculo>().ToList();
        }
        public void DeleteItem(int Id)
        {
            Vehiculo vehiculo = GetById(Id);
            connection.Delete(vehiculo);
        }
    }
}
