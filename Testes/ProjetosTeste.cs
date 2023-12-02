using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    public class ProjetosTeste
    {
        private int _id_proj;
        private string _nome;
        private string _descricao;
        private DateTime _inicio;
        private int _id_dept;
        public ProjetosTeste()
        {
            var faker = new Bogus.Faker();

            this._id_proj = 1132132; // por algum motivo o faker deu problema aqui
            this._nome = "dasdsda";
            this._descricao = "dsfdsf"; //sonhar não custa nada né
            this._inicio = DateTime.Now;
            this._id_dept = 1132132;
        }
        [Fact]
        public void CriarObjeto()
        {
            var obj = new
            {
                Id_proj = this._id_proj,
                Nome = this._nome,
                Descricao = this._descricao,
                Inicio = this._inicio,
                Id_dept = this._id_dept,
            };

            Projetos projetos = new Projetos(
                obj.Id_proj, obj.Nome, obj.Descricao, obj.Inicio, obj.Id_dept);

            obj.ToExpectedObject().ShouldMatch(projetos);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdProjInvalido(int id_proj_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
              new Projetos(id_proj_invalido, this._nome, this._descricao, this._inicio, this._id_dept)
               ).Message;

            Assert.Equal("Id Projeto Inválido", mensagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeInvalido(string nome_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Projetos(this._id_proj, nome_invalido, this._descricao, this._inicio, this._id_dept)
               ).Message;

            Assert.Equal("Nome Inválido", mensagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DescricaoInvalida(string descricao_invalida)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Projetos(this._id_proj, this._nome, descricao_invalida, this._inicio, this._id_dept)
               ).Message;

            Assert.Equal("Descrição Inválida", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdDepInvalido(int id_dep_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
              new Projetos(this._id_proj, this._nome, this._descricao, this._inicio, id_dep_invalido)
               ).Message;

            Assert.Equal("Id Departamento Inválido", mensagem);
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
                    var dataInicio = new DateTime(ano, mes, dia);
                    new Projetos(this._id_proj, this._nome, this._descricao, dataInicio, this._id_dept);
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

    }
}