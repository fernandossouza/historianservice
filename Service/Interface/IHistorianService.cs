using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using historianservice.Model;

namespace historianservice.Service.Interface
{
    public interface IHistorianService
    {
         Task<List<Historian>> getHistorian(int thingId,long dateInitial,long dateEnd);
         Task<List<Historian>> getHistorianPerTag(int thingId,long dateInitial,long dateEnd,string tagName);
         Task<Historian> addHistorian(Historian historian);

    }
}