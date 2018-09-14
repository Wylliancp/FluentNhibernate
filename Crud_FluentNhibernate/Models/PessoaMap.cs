using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_FluentNhibernate.Models
{
    public class PessoaMap : ClassMap<Pessoa>
    {

        public PessoaMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome);
            Map(x => x.Cpf);
            Map(x => x.DataNascimento);
            Map(x => x.FlgAtivo);
            Table("[Pessoa]");
        }
    }
}