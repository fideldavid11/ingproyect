using back.Models;
using back.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace back.Repository.Implementation
{
    public class CedulaRepository : ICedulaRepository
    {
        private readonly CeduladbContext _dbContext;

        public CedulaRepository(CeduladbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cedula> GetAll()
        {
            return _dbContext.Cedulas.ToList();
        }

        public Cedula GetById(int id)
        {
            return _dbContext.Cedulas.FirstOrDefault(c => c.ID == id);
        }

        public bool Add(Cedula cedula)
        {
            try
            {
                _dbContext.Cedulas.Add(cedula);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Cedula cedula)
        {
            try
            {
                _dbContext.Entry(cedula).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Cedula GetByCedulaNumber(string cedulaNumber)
        {
            return _dbContext.Cedulas.FirstOrDefault(c => c.CedulaNumber == cedulaNumber);
        }


        public bool Delete(Cedula cedula)
        {
            try
            {
                _dbContext.Cedulas.Remove(cedula);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
