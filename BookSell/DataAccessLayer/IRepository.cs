﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(IEnumerable<TEntity> entity);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll();
        TEntity GetById(TKey id);
        (IList<TEntity> data, int total, int totalDisplay) Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null);
        TEntity GetFirstOrDefault2(Expression<Func<TEntity, bool>> filter, string? includeProperties = null, bool tracked = true);

		(IList<TEntity> data, int total, int totalDisplay) Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(
           Expression<Func<TEntity, bool>> filter = null,
           string orderBy = null,
           // string includeProperties = "",
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);

        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , bool isTrackingOff = false);

        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>,
             IIncludableQueryable<TEntity, object>> include = null);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);

    }
}