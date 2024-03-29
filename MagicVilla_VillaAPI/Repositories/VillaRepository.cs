﻿using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repositories
{
    public class VillaRepository : Repository<Villa>, IVillarepository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.Updatedate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
