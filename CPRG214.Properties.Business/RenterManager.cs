using CPRG214.Properties.Data;
using CPRG214.Properties.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Properties.Business
{
    public  class RenterManager
    {
        public static IList GetAsKEyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.Renters.Select(o => new
            {
                Value = o.Id,
                Text = o.FirstName +" "+ o.LastName
            }).ToList();
            return types;
        }

        
    }
}
