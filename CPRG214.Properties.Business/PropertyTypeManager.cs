using CPRG214.Properties.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Properties.Business
{
    public class PropertyTypeManager
    {
        public static IList GetAsKEyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.PropertyTypes.Select(o => new
            {
                Value= o.Id,
                Text = o.Style
            }).ToList();
            return types;
        }
    }
}
