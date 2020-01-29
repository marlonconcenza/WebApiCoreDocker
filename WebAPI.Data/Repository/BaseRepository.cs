﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Context;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //private IOptions<AppSettings> settings;
        private SqlServerContext context = null;

        //public BaseRepository(IOptions<AppSettings> settings)
        public BaseRepository()
        {
            //this.settings = settings;
            //this.context = new SqlServerContext(this.settings);
            this.context = new SqlServerContext();
        }
        public async Task Insert(T obj)
        {
            context.Set<T>().Add(obj);
            await context.SaveChangesAsync();
        }
        public async Task Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            context.Set<T>().Remove(await Select(id));
            await context.SaveChangesAsync();
        }

        public async Task<T> Select(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> SelectAll()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
