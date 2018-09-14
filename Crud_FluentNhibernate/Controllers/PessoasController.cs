using Crud_FluentNhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web.Http;

namespace Crud_FluentNhibernate.Controllers
{
    public class PessoasController : ApiController
    {

        public IList<Pessoa> GetPessoas()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Query<Pessoa>().ToList();
                return Ok(pessoa);
            }
        }
    }
}
