using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using historianservice.Model;
using historianservice.Service.Interface;
using historianservice.Data;

namespace historianservice.Service
{
    public class HistorianService : IHistorianService
    {
        private readonly ApplicationDbContext _context;

        public HistorianService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Historian>> getHistorian(int thingId,DateTime dateInitial,DateTime dateEnd)
        {
            var historian = await _context.Historians.OrderBy(x=>x.date)
            .Where(x=> x.thingId == thingId && 
            x.date >= dateInitial && x.date <= dateEnd).ToListAsync();

            return historian;

        }

        public async Task<List<Historian>> getHistorianPerTag(int thingId,DateTime dateInitial,DateTime dateEnd,string tagName)
        {
            var historian = await _context.Historians.OrderBy(x=>x.date)
            .Where(x=> x.thingId == thingId && x.tag == tagName &&
            x.date >= dateInitial && x.date <= dateEnd).ToListAsync();

            return historian;
        }

        public async Task<Historian> addHistorian(Historian historian)
        {
            _context.Historians.Add(historian);
            await _context.SaveChangesAsync();
            return historian;
        }
        
    }
}