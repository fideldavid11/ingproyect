using back.Models;
using System.Collections.Generic;

namespace back.Repository.Abstract
{
    public interface ICedulaRepository
    {
        IEnumerable<Cedula> GetAll();
        Cedula GetById(int id);
        Cedula GetByCedulaNumber(string cedulaNumber); // Nuevo método
        bool Add(Cedula cedula);
        bool Update(Cedula cedula);
        bool Delete(Cedula cedula);
    }
}
