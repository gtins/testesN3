using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Atividade
    {
        private int id_ativ;
        private string descri;
        private DateTime dt_prev_ini;
        private DateTime dt_prev_fim;
        private DateTime dt_real_ini;
        private DateTime dt_real_fim;
        private double qta_horas_prev;
        private double qta_horas_real;
        private int id_projeto;
        private int id_funcionario;
        public int Id_ativ { get => id_ativ; set => id_ativ = value; }
        public string Descri { get => descri; set => descri = value; }
        public DateTime Dt_prev_ini { get => dt_prev_ini; set => dt_prev_ini = value; }
        public DateTime Dt_prev_fim { get => dt_prev_fim; set => dt_prev_fim = value; }
        public DateTime Dt_real_ini { get => dt_real_ini; set => dt_real_ini = value; }
        public DateTime Dt_real_fim { get => dt_real_fim; set => dt_real_fim = value; }
        public double Qta_horas_prev { get => qta_horas_prev; set => qta_horas_prev = value; }
        public double Qta_horas_real { get => qta_horas_real; set => qta_horas_real = value; }
        public int Id_projeto { get => id_projeto; set => id_projeto = value; }
        public int Id_funcionario { get => id_funcionario; set => id_funcionario = value; }


        public Atividade(int id_ativ, string descri, DateTime dt_prev_ini, DateTime dt_prev_fim, DateTime dt_real_ini, 
            DateTime dt_real_fim, double qta_horas_prev, double qta_horas_real, int id_projeto, int id_funcionario)
        {
            if(id_ativ <= 0)
            {
                throw new ArgumentException("Id Atividade Inválido");
            }

            if (id_projeto <= 0)
            {
                throw new ArgumentException("Id Projeto Inválido");
            }

            if (id_funcionario <= 0)
            {
                throw new ArgumentException("Id Funcionário Inválido");
            }

            if (string.IsNullOrEmpty(descri))
            {
                throw new ArgumentException("Descrição Inválida");
            }

            if (qta_horas_prev <= 0)
            {
                throw new ArgumentException("Horas Inválidas");
            }

            if (qta_horas_real <= 0)
            {
                throw new ArgumentException("Horas Inválidas");
            }

            Id_ativ = id_ativ;
            Descri = descri;
            Dt_prev_ini = dt_prev_ini;
            Dt_prev_fim = dt_prev_fim;
            Dt_real_ini = dt_real_ini;
            Dt_real_fim = dt_real_fim;
            Qta_horas_prev = qta_horas_prev;
            Qta_horas_real = qta_horas_real;
            Id_projeto = id_projeto;
            Id_funcionario = id_funcionario;

        }

    }
}