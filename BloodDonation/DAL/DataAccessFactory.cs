using DAL.EF;
using DAL.Interfaces;
using DAL.Reppos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IReppo<Group, int, bool> GroupDataAccess()
        {
            return new GroupReppo();
        }
        public static IReppo<Donor,int,Donor> DonorDataAccess()
        {
            return new DonorReppo();
        }
        public static IReppo<User,string,User> UserDataAccess()
        {
            return new UserReppo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserReppo();
        }
    }
}
