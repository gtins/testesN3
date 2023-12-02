using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Projetos
    {
        private int id_proj;
        private string nome;
        private string descricao;
        private DateTime inicio;
        private int id_dept;

        public int Id_proj { get => id_proj; set => id_proj = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
        public int Id_dept { get => id_dept; set => id_dept = value; }


        public Projetos(int id_proj, string nome, string descricao, DateTime inicio, int id_dept)
        {
            if (id_proj <= 0)
            {
                throw new ArgumentException("Id Projeto Inválido");
            }

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Inválido");
            }

            if (string.IsNullOrEmpty(descricao))
            {
                throw new ArgumentException("Descrição Inválida");
            }

            if (id_dept <= 0)
            {
                throw new ArgumentException("Id Departamento Inválido");
            }

            Id_proj = id_proj;
            Nome = nome;
            Descricao = descricao;
            Inicio = inicio;
            Id_dept = id_dept;
        }

    }
}