using IHotels.Viewer.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.Core
{
    public sealed class DbConnector
    {
        //Singelton that create the context only once.

        private readonly IHotelsContext db;
        private static DbConnector connector;
        private static readonly object key = new object();

        private DbConnector()
        {
            db = new IHotelsContext();
        }

        public static DbConnector GetInstance
        {
            get
            {
                lock (key)
                {
                    connector ??= new DbConnector();
                    return connector;
                }
            }
        }

        public IHotelsContext GetDb()
        {
            return db;
        }
    }
}
