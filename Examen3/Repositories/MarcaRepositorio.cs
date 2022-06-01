using Examen3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen3.Repositories
{
    public class MarcaRepositorio
    {
        SQLiteConnection connection;
        public MarcaRepositorio()
        {
            connection = new SQLiteConnection(Constants.Constantes.DatabasePath, Constants.Constantes.Flags);
            connection.CreateTable<Marca>();
        }
        public void Init()
        {
            connection.CreateTable<Marca>();
        }
        public void InsertOrUpdate(Marca marca)
        {
            if (marca.Id == 0)
            {
                connection.Insert(marca);
            }
            else
            {
                connection.Update(marca);
            }
        }
        public Marca GetById(int Id)
        {
            return connection.Table<Marca>().FirstOrDefault(item => item.Id == Id);
        }
        public List<Marca> GetAll()
        {

            return connection.Table<Marca>().ToList();
        }
        public void DeleteItem(int Id)
        {
            Marca marca = GetById(Id);
            connection.Delete(marca);
        }
    }
}
