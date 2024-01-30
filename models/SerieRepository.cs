using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;


namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();
        public void Update(int id, Serie serieObject)
        {
            seriesList[id] = serieObject;
        }
        public void Delete(int id)
        {
            seriesList[id].Excluir();
        }

        public void Insert(Serie serieObject)
        {
            seriesList.Add(serieObject);
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Serie ReturnById(int id)
        {
            return seriesList[id];
        }
        public List<Serie> Lista()
        {
            return  seriesList; 
        }
    }
}