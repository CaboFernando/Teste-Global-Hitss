using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dao;
using WebApi.Model;

namespace WebApi.Repositorio
{
    public class MotoristaRepositorio
    {
        private readonly DaoMotorista _daoMotorista;

        public MotoristaRepositorio()
        {
            _daoMotorista = new DaoMotorista();
        }

        public List<Motorista> GetMotoristas()
        {
            return _daoMotorista.GetMotoristas();
        }

        public Motorista GetMotorista(int codigo)
        {
            if (codigo <= 0)
                return new Motorista();

            return _daoMotorista.GetMotorista(codigo);
        }

        public void PostMotorista(Motorista motorista)
        {
            _daoMotorista.PostMotorista(motorista);
        }

        public void PutMotorista(Motorista motorista)
        {
            _daoMotorista.PutMotorista(motorista);
        }

        public void DeleteMotorista(int codigo)
        {
            _daoMotorista.DeleteMotorista(codigo);
        }
    }
}
