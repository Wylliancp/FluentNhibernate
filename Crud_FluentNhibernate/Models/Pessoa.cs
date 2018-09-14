using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_FluentNhibernate.Models
{
    public class Pessoa
    {

        public virtual int  Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual int FlgAtivo { get; set; }

    }
}