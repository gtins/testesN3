using Bogus;
using Dominio;
using ExpectedObjects;
using Newtonsoft.Json.Bson;

namespace Testes
{
    public class DepartamentoTeste
    {
        private int _id_depto;
        private string _nome;

        public DepartamentoTeste()
        {
            var faker = new Bogus.Faker();

            this._id_depto = 20438972;
            this._nome = faker.Name.JobArea();
        }

        [Fact]
        public void CriarObjeto()
        {
            var obj = new
            {
                Id_depto = this._id_depto,
                Nome = this._nome,
            };

            Departamento departamento = new Departamento(obj.Id_depto, obj.Nome);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdDepartamentoInvalido(int id_dept_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
            () =>
            new Departamento(id_dept_invalido, this._nome)).Message;
            Assert.Equal("Id Departamento Inválido", mensagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeInvalido(string nome_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Departamento(this._id_depto, nome_invalido)).Message;

            Assert.Equal("Nome Inválido", mensagem);
        }
    }
}
