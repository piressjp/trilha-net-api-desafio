using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Services
{
    public interface ITarefaService
    {
        Tarefa GetById(int id);
        List<Tarefa> GetAll();
        void Create(Tarefa tarefa);
        void Delete(Tarefa tarefa);
        Tarefa GetByTitle(string titulo);
        IQueryable<Tarefa> GetByDate(DateTime data);
        IQueryable<Tarefa> GetByStatus(EnumStatusTarefa status);
        void Update(Tarefa tarefaBanco, Tarefa tarefa);
    }

    public class TarefaService : ITarefaService
    {
        private readonly OrganizadorContext _context;
        public TarefaService(OrganizadorContext context)
        {
            _context = context;
        }

        public Tarefa GetById(int id)
        {
            return _context.Tarefas.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public List<Tarefa> GetAll()
        {
            return _context.Tarefas.AsNoTracking().ToList();
        }

        public Tarefa GetByTitle(string titulo)
        {
            return _context.Tarefas.AsNoTracking().FirstOrDefault(t => t.Titulo == titulo);
        }

        public IQueryable<Tarefa> GetByDate(DateTime data)
        {
            return _context.Tarefas.Where(x => x.Data.Date == data.Date);
        }
        public IQueryable<Tarefa> GetByStatus(EnumStatusTarefa status)
        {
            return _context.Tarefas.Where(x => x.Status == status);
        }
        
        public void Create(Tarefa tarefa) 
        {
            _context.Tarefas.AddAsync(tarefa);
            _context.SaveChanges();
        }

        public void Update(Tarefa tarefaBanco, Tarefa tarefa)
        {
            tarefa.Id = tarefaBanco.Id;
            tarefaBanco = tarefa;

            _context.Update(tarefaBanco);
            _context.SaveChanges();
        }

        public void Delete(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }
    }

}