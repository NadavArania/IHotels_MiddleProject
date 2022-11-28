using IHotels.Viewer.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Core
{
    public interface IConnectorDb
    {
        //Getting acces to db.

        public static IHotelsContext db {get; set;}
    }
}
