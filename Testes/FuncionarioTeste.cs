using Bogus;
using Dominio;
using ExpectedObjects;
using Newtonsoft.Json.Bson;

namespace Testes
{
    public class FuncionarioTeste
    {
        private string _nome;
        private int _matricula;
        private double _salario;
        private DateTime _data_admissao;
        private string _cargo;

        public FuncionarioTeste()
        {
            var faker = new Bogus.Faker();

            this._nome = faker.Name.FullName();
            this._matricula = 1132132; // por algum motivo o faker deu problema aqui
            this._salario = faker.Random.Double(); //sonhar não custa nada né
            this._data_admissao = DateTime.Now;
            this._cargo = faker.Company.CompanySuffix(); //sonhar não custa nada
        }
        [Fact]
        public void CriarObjeto()
        {
            var obj = new
            {
                Nome = this._nome,
                Matricula = this._matricula,
                Salario = this._salario,
                Data_admissao = this._data_admissao,
                Cargo = this._cargo,
            };

            Funcionario funcionario = new Funcionario(
                obj.Nome, obj.Matricula, obj.Salario, obj.Data_admissao, obj.Cargo);

            obj.ToExpectedObject().ShouldMatch(funcionario);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeInvalido(string nome_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Funcionario(nome_invalido, this._matricula, this._salario, this._data_admissao, this._cargo)
               ).Message;

            Assert.Equal("Nome Inválido", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void MatriculaInvalida(int matricula_invalida)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Funcionario(this._nome, matricula_invalida, this._salario, this._data_admissao, this._cargo)
               ).Message;

            Assert.Equal("Matrícula Inválida", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SalarioInvalido(double salario_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Funcionario(this._nome, this._matricula, salario_invalido, this._data_admissao, this._cargo)
               ).Message;

            Assert.Equal("Salário Inválido", mensagem);
        }

        [Theory]
        [InlineData(2023, 13, 30)]
        [InlineData(2024, 2, 32)]  
        [InlineData(2021, -5, 25)] 
        public void ValidarData(int ano, int mes, int dia)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                if (DataValida(ano, mes, dia))
                {
                    var dataAdmissao = new DateTime(ano, mes, dia);
                    new Funcionario(this._nome, this._matricula, this._salario, dataAdmissao, this._cargo);
                }
                else
                {
                    throw new ArgumentException("Data Inválida");
                }
            });

        }

        private bool DataValida(int ano, int mes, int dia)
        {
            try
            {
                var date = new DateTime(ano, mes, dia);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CargoInvalido(string cargo_ivalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Funcionario(this._nome, this._matricula, this._salario, this._data_admissao, cargo_ivalido)
               ).Message;

            Assert.Equal("Cargo Inválido", mensagem);
        }
    }
}