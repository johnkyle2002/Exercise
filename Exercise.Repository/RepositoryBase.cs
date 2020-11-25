using Exercise.Interface.Repository;
using Exercise.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.Repository
{
    // Unit of work
    public class RepositoryBase<TEntity>: IRepositoryBase<TEntity> where TEntity : class
    {

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Database context.</param>
        public RepositoryBase(PaymentDBContext context, ILogger<RepositoryBase<TEntity>> logger)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region Private Members

        private readonly PaymentDBContext _context;
        private readonly ILogger<RepositoryBase<TEntity>> _logger;

        #endregion

        #region Properties

        /// <summary>
        /// Get the entity.
        /// </summary>
        public DbSet<TEntity> Entity
        {
            get { return _context.Set<TEntity>(); }
        }

        #endregion

        #region Persistence

        /// <summary>
        /// This will add new entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Add(TEntity entity, bool saveChanges = true)
        {
            try
            {
                Entity.Add(entity);
                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Add TEntity", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously add new entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(TEntity entity, bool saveChanges = true)
        {
            try
            {
                await Entity.AddAsync(entity);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("AddAsync TEntity", ex);
                return false;
            }
        }

        /// <summary>
        /// This will add new list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Add(IList<TEntity> entities, bool saveChanges = true)
        {
            try
            {
                Entity.AddRange(entities);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Add List<Tentity>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously add new list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(IList<TEntity> entities, bool saveChanges = true)
        {
            try
            {
                await Entity.AddRangeAsync(entities);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("AddAsync IList<TEntity>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will update an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Update(TEntity entity, bool saveChanges = true, byte[] concurrencyStamp = null)
        {
            try
            {
                Entity.Update(entity).State = EntityState.Modified;

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Update TEntity", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Update TEntity", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously update an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntity entity, bool saveChanges = true, byte[] concurrencyStamp = null)
        {
            try
            {
                Entity.Update(entity).State = EntityState.Modified;

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("UpdateAsync TEntity", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateAsync TEntity", ex);
            }
            return false;
        }

        /// <summary>
        /// This will remove an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Remove(TEntity entity, bool saveChanges = true)
        {
            try
            {
                Entity.Remove(entity);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Remove TEntity", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously remove an entity to the context.
        /// </summary>
        /// <param name="entity">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(TEntity entity, bool saveChanges = true)
        {
            try
            {
                Entity.Remove(entity);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("RemoveAsync TEntity", ex);
                return false;
            }
        }

        /// <summary>
        /// This will remove a list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public bool Remove(IList<TEntity> entities, bool saveChanges = true)
        {
            try
            {
                Entity.RemoveRange(entities);

                if (saveChanges)
                    return SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Remove IList<TEntity>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will asynchronously remove a list of entities to the context.
        /// </summary>
        /// <param name="entities">The entity class.</param>
        /// <param name="saveChanges">Flags if will save the changes made to the context.</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(IList<TEntity> entities, bool saveChanges = true)
        {
            try
            {
                Entity.RemoveRange(entities);

                if (saveChanges)
                    return await SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("RemoveAsync IList<TEntity>", ex);
                return false;
            }
        }

        /// <summary>
        /// This will save the changes made to the database context.
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("SaveChange", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("SaveChange", ex);
            }
            return false;
        }

        /// <summary>
        /// This will asynchronously saves the changes made to the database context.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("SaveChangeAsync", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("SaveChangeAsync", ex);
                return false;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Implementation for database context dispose.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();            
        }

        #endregion
    }
}
