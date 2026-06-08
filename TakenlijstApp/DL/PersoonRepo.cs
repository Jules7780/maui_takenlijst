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
    public class PersoonRepo : IPersoonRepo
    {
        public PersoonRepo(DatabankConnectie db)
        {
            Db = db;
        }

        public DatabankConnectie Db {  get; set; }

        public ILiteCollection<Persoon> HaalCollectie()
        {
            return Db.HaalCollectie<Persoon>();
        }

        public Persoon HaalMetId(int persoonId)
        {
            return HaalCollectie().FindById(persoonId);
        }

        public List<Persoon> HaalAllePersonen()
        {
            return HaalCollectie().FindAll().ToList();
        }

        public bool Exists(Persoon p)
        {
            return HaalCollectie().Exists(o => o.Id == p.Id);
        }

        public void Toevoegen(Persoon p)
        {
            HaalCollectie().Insert(p);
        }

        public void Update(Persoon p)
        {
            HaalCollectie().Update(p);
        }

        public bool Verwijderen(Persoon p)
        {
            return HaalCollectie().Delete(p.Id);
        }
    }
}
