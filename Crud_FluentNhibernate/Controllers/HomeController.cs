using Crud_FluentNhibernate.Models;
using NHibernate;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Crud_FluentNhibernate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var pessoas = session.Query<Pessoa>().ToList();
                return View(pessoas);
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoa);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(pessoa);
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Get<Pessoa>(id);
                return View(pessoa);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var pessoaUpdate = session.Get<Pessoa>(id);

                    pessoaUpdate.Nome = pessoa.Nome;
                    pessoaUpdate.Cpf = pessoa.Cpf;
                    pessoaUpdate.DataNascimento = pessoa.DataNascimento;
                    pessoaUpdate.FlgAtivo = pessoa.FlgAtivo;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoaUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Get<Pessoa>(id);
                return View(pessoa);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Get<Pessoa>(id);
                return View(pessoa);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(pessoa);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

    }
}