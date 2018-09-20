using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DALBase
    {
        protected CarRentalEntities db;

        public DALBase()
        {
            db = new CarRentalEntities();
        }

    //    public override bool Equals(object obj)
    //    {
    //        return base.Equals(obj);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }

    //    public override string ToString()
    //    {
    //        return base.ToString();
    //    }
    }
}
