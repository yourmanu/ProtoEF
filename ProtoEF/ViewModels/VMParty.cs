using ProtoEF.Data;
using ProtoEF.Models;
using System.Collections.Generic;
using System.Linq;


namespace ProtoEF.ViewModels
{
    public class VMParty
    {
        public VMParty(ApplicationDbContext db,bool emptyModel=true)
        {
            Countries = db.Countries.ToList();
            PaymentTerms = db.PaymentTerms.ToList();
            if (emptyModel)
            {
                Parties = new List<Party>();
            }
            else
            {
                Parties = db.Parties.ToList();
            }
            
        }
        public IEnumerable<Party> Parties { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<PaymentTerm> PaymentTerms { get; set; }
    }
}