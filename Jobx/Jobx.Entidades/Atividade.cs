using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobx.Entidades
{
    public class Atividade
    {
        public virtual int IdAtividade { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataAtividade { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        public Atividade()
        {

        }

        public Atividade(int idAtividade, string nome, DateTime dataAtividade)
        {
            IdAtividade = idAtividade;
            Nome = nome;
            DataAtividade = dataAtividade;
        }

        public override string ToString()
        {
            return $"Id da Atividade: {IdAtividade}, Nome: {Nome}";
        }
    }
}
