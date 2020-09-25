using CPRG214.Properties.Data;
using CPRG214.Properties.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Properties.Business
{
    public class OwnerManager
    {

        public static List<Owner> GetAll()
        {
            var context = new RentalsContext();
            var owners = context.Owners.OrderBy(p => p.Name).ToList();
            return owners;

        }

        public static void Add(Owner owner)
        {
            var context = new RentalsContext();
            context.Owners.Add(owner);
            context.SaveChanges();

        }

        public static void Update(Owner owner)
        {
            var context = new RentalsContext();
            var originalOwner = context.Owners.Find(owner.Id);
            originalOwner.Name = owner.Name;
            originalOwner.Phone = owner.Phone;
            context.SaveChanges();

        }

        public static Owner Find(int id)
        {
            var context = new RentalsContext();
            var originalOwner = context.Owners.Find(id);
            return originalOwner;

        }

        public static IList GetAsKEyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.Owners.Select(o => new
            {
                Value = o.Id,
                Text = o.Name
            }).ToList();
            return types;
        }
    }
}
