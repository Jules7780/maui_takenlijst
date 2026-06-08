using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DatabankConnectie
    {
        private LiteDatabase _db;

        public DatabankConnectie()
        {
            _db = new LiteDatabase("takenlijst.db");
        }

        public ILiteCollection<T> HaalCollectie<T>()
        {
            return _db.GetCollection<T>();
        }
    }
}
