using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Web_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public List<wsLogin> getLogin()
        {
            mspbudbDataContext dc = new mspbudbDataContext();
            List<wsLogin> results = new List<wsLogin>();

            foreach (login lgn in dc.logins)
            {
                results.Add(new wsLogin()
                {
                    username = lgn.username,
                    password = lgn.password
                });
            }

            return results;
        }

        public List<wsPassword> getPassword(string username)
        {
            mspbudbDataContext dc = new mspbudbDataContext();
            List<wsPassword> results = new List<wsPassword>();

            foreach (login lgn in dc.logins.Where(s => s.username == username))
            {
                results.Add(new wsPassword()
                {
                    password = lgn.password
                });
            }

            return results;
        }
    }
}
