using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Web_Service.Model;
using Newtonsoft.Json;
using System.Data.Entity;

namespace Web_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {

        mspbuEntities mspbu = new mspbuEntities();

        #region Dispencer Service

        #endregion


        #region Login Service
        public List<login> getLogin()
        {
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
        #endregion


        #region Spp Service
        public string sppGet(int idRequest)
        {
            spp sppFound = mspbu.spps.Find(idRequest);

            return convertTypeToJson(sppFound);
        }
        public string sppGetAll()
        {
            List<spp> sppsFound = mspbu.spps.ToList();

            return convertTypeToJson(sppsFound);
        }
        public string sppGetWhere(spp sppAttributes)
        {
            List<spp> sppsFound = mspbu.spps.ToList();
            if (sppAttributes.address != null)
                sppsFound = sppsFound.Where(s => s.address == sppAttributes.address).ToList();
            if (sppAttributes.print_date != null)
                sppsFound = sppsFound.Where(s => s.print_date == sppAttributes.print_date).ToList();
            if (sppAttributes.verification_date != null)
                sppsFound = sppsFound.Where(s => s.verification_date == sppAttributes.verification_date).ToList();
            if (sppAttributes.buyer != null)
                sppsFound = sppsFound.Where(s => s.buyer == sppAttributes.buyer).ToList();
            if (sppAttributes.dens_temp != null)
                sppsFound = sppsFound.Where(s => s.dens_temp == sppAttributes.dens_temp).ToList();
            if (sppAttributes.name != null)
                sppsFound = sppsFound.Where(s => s.name == sppAttributes.name).ToList();
            if (sppAttributes.police_no != null)
                sppsFound = sppsFound.Where(s => s.police_no == sppAttributes.police_no).ToList();
            if (sppAttributes.product != null)
                sppsFound = sppsFound.Where(s => s.product == sppAttributes.product).ToList();
            if (sppAttributes.shipment_no != null)
                sppsFound = sppsFound.Where(s => s.shipment_no == sppAttributes.shipment_no).ToList();
            if (sppAttributes.volume != null)
                sppsFound = sppsFound.Where(s => s.volume == sppAttributes.volume).ToList();
            
            return convertTypeToJson(sppsFound);
        }

        public string sppInsert(spp sppRequest)
        {
            //spp sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));

            mspbu.spps.Add(sppRequest);
            int rowAffected = mspbu.SaveChanges();

            return rowAffected + " row inserted";
        }
        
        public string sppInsertBatch(spp[] sppListRequest)
        {
            //spp sppRequest = new spp();
            //List<string> sppListRequest = (List<string>)convertJsonToType(sppListRequestJson, typeof(List<string>));
            foreach (spp sppRequest in sppListRequest)
            {
                //sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));
                mspbu.spps.Add(sppRequest);
            }

            int rowAffected = mspbu.SaveChanges();
            return rowAffected + " row(s) inserted";
        }

        public string sppUpdate(spp sppRequest)
        {
            //spp sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));
            spp sppFound = mspbu.spps.Find(sppRequest.Id);

            if (sppFound != null)
            {
                sppFound.name = (sppRequest.name != null) ? sppRequest.name : sppFound.name;
                sppFound.police_no = (sppRequest.police_no != null) ? sppRequest.police_no : sppFound.police_no;
                sppFound.product = (sppRequest.product != null) ? sppRequest.product : sppFound.product;
                sppFound.shipment_no = (sppRequest.shipment_no != null) ? sppRequest.shipment_no : sppFound.shipment_no;
                sppFound.volume = (sppRequest.volume != null) ? sppRequest.volume : sppFound.volume;
                sppFound.address = (sppRequest.address != null) ? sppRequest.address : sppFound.address;
                sppFound.verification_date = (sppRequest.verification_date != null) ? sppRequest.verification_date : sppFound.verification_date;
                sppFound.print_date = (sppRequest.print_date != null) ? sppRequest.print_date : sppFound.print_date;
                sppFound.buyer = (sppRequest.buyer != null) ? sppRequest.buyer : sppFound.buyer;
                sppFound.dens_temp = (sppRequest.dens_temp != null) ? sppRequest.dens_temp : sppFound.dens_temp;

                mspbu.Entry(sppFound).State = EntityState.Modified;
            }
            int rowAffected = mspbu.SaveChanges();

            return rowAffected + " row updated";
        }

        public string sppUpdateBatch(spp[] sppListRequest)
        {
            //spp sppRequest = new spp();
            spp sppFound = new spp();
            //string[] sppListRequest = (string[])convertJsonToType(sppListRequestJson, typeof(string[]));
            foreach (spp sppRequest in sppListRequest)
            {
                //sppRequest = sppRequestJson;
                sppFound = mspbu.spps.Find(sppRequest.Id);

                if (sppFound != null)
                {
                    sppFound.name = (sppRequest.name != null) ? sppRequest.name : sppFound.name;
                    sppFound.police_no = (sppRequest.police_no != null) ? sppRequest.police_no : sppFound.police_no;
                    sppFound.product = (sppRequest.product != null) ? sppRequest.product : sppFound.product;
                    sppFound.shipment_no = (sppRequest.shipment_no != null) ? sppRequest.shipment_no : sppFound.shipment_no;
                    sppFound.volume = (sppRequest.volume != null) ? sppRequest.volume : sppFound.volume;
                    sppFound.address = (sppRequest.address != null) ? sppRequest.address : sppFound.address;
                    sppFound.print_date = (sppRequest.print_date != null) ? sppRequest.print_date : sppFound.print_date;
                    sppFound.verification_date = (sppRequest.verification_date != null) ? sppRequest.verification_date : sppFound.verification_date;
                    sppFound.buyer = (sppRequest.buyer != null) ? sppRequest.buyer : sppFound.buyer;
                    sppFound.dens_temp = (sppRequest.dens_temp != null) ? sppRequest.dens_temp : sppFound.dens_temp;

                    mspbu.Entry(sppFound).State = EntityState.Modified;
                }
            }
            int rowAffected = mspbu.SaveChanges();

            return rowAffected + " row(s) updated";
        }

        public string sppDelete(int idRequest)
        {
            spp sppFound = mspbu.spps.Find(idRequest);
            if (sppFound != null)
                mspbu.spps.Remove(sppFound);
            int rowAffected = mspbu.SaveChanges();

            return rowAffected + " row deleted";
        }
        public string sppDeleteBatch(int[] idListRequest)
        {
            //List<int> idListRequest = (List<int>)convertJsonToType(idListRequestJson, typeof(List<int>));
            foreach (int idRequest in idListRequest)
            {
                spp sppFound = mspbu.spps.Find(idRequest);
                if (sppFound != null)
                    mspbu.spps.Remove(sppFound);
            }
            int rowAffected = mspbu.SaveChanges();

            return rowAffected + " row(s) deleted";
        }
        #endregion


        #region Stock Service

        #endregion


        #region Support Module
        private object convertJsonToType(string jsonObject, Type objType)
        {
            string sppSentString = JsonConvert.DeserializeObject(jsonObject).ToString();
            return JsonConvert.DeserializeObject(sppSentString, objType);
        }
        private string convertTypeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        #endregion

    }
}
