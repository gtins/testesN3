namespace Dominio
{
    public class Funcionario
    {
        private string nome;
        private int matricula;
        private double salario;
        private DateTime data_admissao;
        private string cargo;

        public string Nome { get => nome; set => nome = value; }
        public int Matricula { get => matricula; set => matricula = value; }
        public double Salario { get => salario; set => salario = value; }
        public DateTime Data_admissao { get => data_admissao; set => data_admissao = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Funcionario(string nome, int matricula, double salario, DateTime data_admissao, string cargo)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Inválido");
            }

            if (matricula <= 0)
            {
                throw new ArgumentException("Matrícula Inválida");
            }

            if (salario <= 0)
            {
                throw new ArgumentException("Salário Inválido");
            }

            if(string.IsNullOrEmpty(cargo))
            {
                throw new ArgumentException("Cargo Inválido");
            }


            //o resto

            Nome = nome;
            Matricula = matricula;
            Salario = salario;
            Data_admissao = data_admissao;
            Cargo = cargo;
        }

    }
}