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
        public List<login> getLogin()
        {
            mspbuEntities mspbu = new mspbuEntities();
            List<login> results = new List<login>();

            foreach (login lgn in mspbu.logins)
            {
                results.Add(new login()
                {
                    username = lgn.username,
                    password = lgn.password
                });
            }

            return results;
        }

        public List<string> getPassword(string username)
        {
            mspbuEntities mspbu = new mspbuEntities();
            List<string> results = new List<string>();

            foreach (login lgn in mspbu.logins.Where(s => s.username == username))
            {
                results.Add(lgn.password);
            }

            return results;
        }
    }
}
