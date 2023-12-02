using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Departamento
    {
        private int id_depto;
        private string nome;
        public int Id_depto { get => id_depto; set => id_depto = value; }
        public string Nome { get => nome; set => nome = value; }

        public Departamento(int id_depto, string nome)
        {
            if (id_depto <= 0)
            {
                throw new ArgumentException("Id Departamento Inválido");
            }

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Inválido");
            }

            Id_depto = id_depto;
            Nome = nome;
        }
    }
}
