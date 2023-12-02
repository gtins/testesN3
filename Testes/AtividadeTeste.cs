using Bogus.DataSets;
using Dominio;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    public class AtividadeTeste
    {
        private int _id_ativ;
        private string _descri;
        private DateTime _dt_prev_ini;
        private DateTime _dt_prev_fim;
        private DateTime _dt_real_ini;
        private DateTime _dt_real_fim;
        private double _qta_horas_prev;
        private double _qta_horas_real;
        private int _id_projeto;
        private int _id_funcionario;
        public AtividadeTeste()
        {
            var faker = new Bogus.Faker();

            this._id_ativ = 1;
            this._descri = "dsoiuuihd";
            this._dt_prev_ini = new DateTime(2023, 12, 31);
            this._dt_prev_fim = new DateTime(2023, 12, 31);
            this._dt_real_ini = new DateTime(2023, 12, 31);
            this._dt_real_fim = new DateTime(2023, 12, 31);
            this._qta_horas_prev = 30;
            this._qta_horas_real = 20;
            this._id_projeto = 12;
            this._id_funcionario = 13;
        }
        [Fact]
        public void CriarObjeto()
        {
            var obj = new
            {
                Id_ativ = this._id_ativ,
                Descri = this._descri,
                Dt_prev_ini = this._dt_prev_ini,
                Dt_prev_fim = this._dt_prev_fim,
                Dt_real_ini = this._dt_real_ini,
                Dt_real_fim = this._dt_real_fim,
                Qta_horas_prev = this._qta_horas_prev,
                Qta_horas_real = this._qta_horas_real,
                Id_projeto = this._id_projeto,
                Id_funcionario = this._id_funcionario,

            };

            Atividade atividade = new Atividade(
                obj.Id_ativ, obj.Descri, obj.Dt_prev_ini, obj.Dt_prev_fim, obj.Dt_real_ini, obj.Dt_real_fim, obj.Qta_horas_prev, obj.Qta_horas_real, obj.Id_projeto, obj.Id_funcionario);

            obj.ToExpectedObject().ShouldMatch(atividade);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdAtivInvalido(int id_ativ_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
            () =>
            new Atividade(id_ativ_invalido, this._descri, this._dt_prev_ini, this._dt_prev_fim, this._dt_real_ini, this._dt_real_fim,
            this._qta_horas_prev, this._qta_horas_real, this._id_projeto, this._id_funcionario)).Message;
            Assert.Equal("Id Atividade Inválido", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdProjetoInvalido(int id_proj_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
            () =>
            new Atividade(this._id_ativ, this._descri, this._dt_prev_ini, this._dt_prev_fim, this._dt_real_ini, this._dt_real_fim,
            this._qta_horas_prev, this._qta_horas_real, id_proj_invalido, this._id_funcionario)).Message;
            Assert.Equal("Id Projeto Inválido", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdFuncionarioInvalido(int id_func_invalido)
        {
            var mensagem = Assert.Throws<ArgumentException>(
            () =>
            new Atividade(this._id_ativ, this._descri, this._dt_prev_ini, this._dt_prev_fim, this._dt_real_ini, this._dt_real_fim,
            this._qta_horas_prev, this._qta_horas_real, this._id_projeto, id_func_invalido)).Message;
            Assert.Equal("Id Funcionário Inválido", mensagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DescInvalida(string desc_invalida)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Atividade(this._id_ativ, desc_invalida, this._dt_prev_ini, this._dt_prev_fim, this._dt_real_ini, this._dt_real_fim,
            this._qta_horas_prev, this._qta_horas_real, this._id_projeto, this._id_funcionario)).Message;

            Assert.Equal("Descrição Inválida", mensagem);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void HorasInvalidas(double hora_invalida)
        {
            var mensagem = Assert.Throws<ArgumentException>(
                () =>
               new Atividade(this._id_ativ, this._descri, this._dt_prev_ini, this._dt_prev_fim, this._dt_real_ini, this._dt_real_fim,
            hora_invalida, hora_invalida, this._id_projeto, this._id_funcionario)).Message;

            Assert.Equal("Horas Inválidas", mensagem);
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
                    var data = new DateTime(ano, mes, dia);
                    new Atividade(this._id_ativ, this._descri, data, data, data, data,
                        this._qta_horas_prev, this._qta_horas_real, this._id_projeto, this._id_funcionario);
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