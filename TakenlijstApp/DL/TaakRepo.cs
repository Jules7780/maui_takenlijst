using BL.Interfaces;
using BL.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class TaakRepo : ITaakRepo
    {
        public TaakRepo(DatabankConnectie db)
        {
            Db = db;
        }

        public DatabankConnectie Db { get; set; }

        public ILiteCollection<Taak> HaalCollectie()
        {
            return Db.HaalCollectie<Taak>();
        }

        public Taak HaalMetId(int taakId)
        {
            return HaalCollectie().FindById(taakId);
        }

        public List<Taak> HaalAlleTaken()
        {
            return HaalCollectie().FindAll().ToList();
        }

        public bool Exists(Taak t)
        {
            return HaalCollectie().Exists(o => o.Id == t.Id);
        }

        public void Toevoegen(Taak t)
        {
            HaalCollectie().Insert(t);
        }

        public void Update(Taak t)
        {
            HaalCollectie().Update(t);
        }

        public bool Verwijderen(Taak t)
        {
            return HaalCollectie().Delete(t.Id);
        }
    }
}
