﻿using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServicesBase<T> where T : class
    {
        BankAccountTypeContext _context;
        DbSet<T> _dbSet;
        public ServicesBase() { 
            _context = new BankAccountTypeContext();
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        
        public void Add(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public bool Update(T entity)
        {
            try {
                var tracker = _context.Attach(entity);
                tracker.State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch { 
                return false;
            }

        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

    }
}
