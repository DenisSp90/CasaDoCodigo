using CasaDoCodigo.Models;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novocadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novocadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == cadastroId)
                .FirstOrDefault();

            if (cadastroDB == null)
                throw new ArgumentNullException("cadastro");

            cadastroDB.Update(novocadastro);
            context.SaveChanges();

            return cadastroDB;

        }
    }
}
