using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Entidades
{
    public class Funcionario
    {
        public virtual int IdFuncionario { get; set; }
        public virtual string Matricula { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        public virtual IList<Atividade> Atividades { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(int idFuncionario, string matricula, string nome, string telefone, DateTime dataNascimento, DateTime dataCadastro)
        {
            IdFuncionario = idFuncionario;
            Matricula = matricula;
            Nome = nome;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
        }

        public override string ToString()
        {
            return $"Id: {IdFuncionario}, nome: {Nome}";
        }
    }
}
