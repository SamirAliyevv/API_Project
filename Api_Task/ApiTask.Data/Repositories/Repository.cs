﻿using ApiTask.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiTask.Data.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : class
    {

        private readonly StudentDbContext _context;
        public Repository(StudentDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
              _context.Set<TEntity>().Add(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes != null && includes.Length>0)
            {

                foreach (var item in includes)
                {

                    query = query.Include(item);
                }
              

            }
            return query.FirstOrDefault(exp);

        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();


            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {

                    query = query.Include(item);
                }


            }
            return query.Where(exp);


        }

        public bool isExists(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();


            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {

                    query = query.Include(item);
                }


            }
            return query.Any(exp);


        }
    }
}
