using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Web_Service.Model;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Script.Serialization;

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
        public int validateLogin(string username, string password)
        {
            login lgn = mspbu.logins.Where(s => s.username == username).FirstOrDefault();

            if (lgn == null) return -2;

            if (login.validatePassword(password, lgn.password)) return 0;

            return -1;
        }

        public int createLogin(string username, string password)
        {
            login lgn = mspbu.logins.Where(s => s.username == username).FirstOrDefault();

            if (lgn == null)
            {
                mspbu.logins.Add(new login()
                    {
                        username = username,
                        password = login.createHash(username, password)
                    });

                //try
                //{
                //    mspbu.SaveChanges();
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    var errorMessage = ex.EntityValidationErrors
                //        .SelectMany(x => x.ValidationErrors)
                //        .Select(x => x.ErrorMessage);

                //    var fullyErrorMessage = string.Join("; ", errorMessage);
                //    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullyErrorMessage);
                //    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                //}

                mspbu.SaveChanges();
                return 0;
            }

            return -1;
        }
        #endregion


        #region Spp Service
        public spp sppGet(int sppId)
        {
            return mspbu.spps.Find(sppId);
            //spp sppFound = mspbu.spps.Find(idRequest);

            //return convertTypeToJson(sppFound);
        }
        public List<spp> sppGetAll()
        {
            return mspbu.spps.ToList();
            //List<spp> sppsFound = mspbu.spps.ToList();

            //return convertTypeToJson(sppsFound);
        }
        public List<spp> sppGetWhere(spp sppData)
        {
            List<spp> sppFound = mspbu.spps.ToList();
            if (sppData.Id != null)
                sppFound = sppFound.Where(s => s.Id == sppData.Id).ToList();
            if (sppData.name != null)
                sppFound = sppFound.Where(s => s.name == sppData.name).ToList();
            if (sppData.address != null)
                sppFound = sppFound.Where(s => s.address == sppData.address).ToList();
            if (sppData.police_no != null)
                sppFound = sppFound.Where(s => s.police_no == sppData.police_no).ToList();
            if (sppData.shipment_no != null)
                sppFound = sppFound.Where(s => s.shipment_no == sppData.shipment_no).ToList();
            if (sppData.volume != null)
                sppFound = sppFound.Where(s => s.volume == sppData.volume).ToList();
            if (sppData.dens_temp != null)
                sppFound = sppFound.Where(s => s.dens_temp == sppData.dens_temp).ToList();
            if (sppData.buyer != null)
                sppFound = sppFound.Where(s => s.buyer == sppData.buyer).ToList();
            if (sppData.product != null)
                sppFound = sppFound.Where(s => s.product == sppData.product).ToList();
            if (sppData.print_date != null)
                sppFound = sppFound.Where(s => s.print_date == sppData.print_date).ToList();
            if (sppData.verification_date != null)
                sppFound = sppFound.Where(s => s.verification_date == sppData.verification_date).ToList();
            if (sppData.status != null)
                sppFound = sppFound.Where(s => s.status == sppData.status).ToList();
            if (sppData.arrival_date != null)
                sppFound = sppFound.Where(s => s.arrival_date == sppData.arrival_date).ToList();
            
            return sppFound;
        }

        public int sppInsert(spp sppData)
        {
            //spp sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));

            mspbu.spps.Add(sppData);
            return mspbu.SaveChanges();
            //int rowAffected = mspbu.SaveChanges();

            //return rowAffected + " row inserted";
        }

        public int sppInsertBatch(List<spp> sppList)
        {
            //spp sppRequest = new spp();
            //List<string> sppListRequest = (List<string>)convertJsonToType(sppListRequestJson, typeof(List<string>));
            foreach (spp sppData in sppList)
            {
                //sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));
                mspbu.spps.Add(sppData);
            }
            return mspbu.SaveChanges();

            //int rowAffected = mspbu.SaveChanges();
            //return rowAffected + " row(s) inserted";
        }

        public int sppUpdate(spp sppData)
        {
            //spp sppRequest = (spp)convertJsonToType(sppRequestJson, typeof(Model.spp));
            spp sppFound = mspbu.spps.Find(sppData.Id);

            if (sppFound != null)
            {
                sppFound.name = (sppData.name != null) ? sppData.name : sppFound.name;
                sppFound.address = (sppData.address != null) ? sppData.address : sppFound.address;
                sppFound.police_no = (sppData.police_no != null) ? sppData.police_no : sppFound.police_no;
                sppFound.shipment_no = (sppData.shipment_no != null) ? sppData.shipment_no : sppFound.shipment_no;
                sppFound.volume = (sppData.volume != null) ? sppData.volume : sppFound.volume;
                sppFound.dens_temp = (sppData.dens_temp != null) ? sppData.dens_temp : sppFound.dens_temp;
                sppFound.buyer = (sppData.buyer != null) ? sppData.buyer : sppFound.buyer;
                sppFound.product = (sppData.product != null) ? sppData.product : sppFound.product;
                sppFound.print_date = (sppData.print_date != null) ? sppData.print_date : sppFound.print_date;
                sppFound.verification_date = (sppData.verification_date != null) ? sppData.verification_date : sppFound.verification_date;
                sppFound.status = (sppData.status != null) ? sppData.status : sppFound.status;
                sppFound.arrival_date = (sppData.arrival_date != null) ? sppData.arrival_date : sppFound.arrival_date;

                mspbu.Entry(sppFound).State = EntityState.Modified;
                return mspbu.SaveChanges();
            }
            return -1;
            //int rowAffected = mspbu.SaveChanges();

            //return rowAffected + " row updated";
        }

        public int sppUpdateBatch(List<spp> sppList)
        {
            //spp sppRequest = new spp();
            //spp sppFound = new spp();
            //string[] sppListRequest = (string[])convertJsonToType(sppListRequestJson, typeof(string[]));
            foreach (spp sppData in sppList)
            {
                //sppRequest = sppRequestJson;
                spp sppFound = mspbu.spps.Find(sppData.Id);

                if (sppFound != null)
                {
                    sppFound.name = (sppData.name != null) ? sppData.name : sppFound.name;
                    sppFound.address = (sppData.address != null) ? sppData.address : sppFound.address;
                    sppFound.police_no = (sppData.police_no != null) ? sppData.police_no : sppFound.police_no;
                    sppFound.shipment_no = (sppData.shipment_no != null) ? sppData.shipment_no : sppFound.shipment_no;
                    sppFound.volume = (sppData.volume != null) ? sppData.volume : sppFound.volume;
                    sppFound.dens_temp = (sppData.dens_temp != null) ? sppData.dens_temp : sppFound.dens_temp;
                    sppFound.buyer = (sppData.buyer != null) ? sppData.buyer : sppFound.buyer;
                    sppFound.product = (sppData.product != null) ? sppData.product : sppFound.product;
                    sppFound.print_date = (sppData.print_date != null) ? sppData.print_date : sppFound.print_date;
                    sppFound.verification_date = (sppData.verification_date != null) ? sppData.verification_date : sppFound.verification_date;
                    sppFound.status = (sppData.status != null) ? sppData.status : sppFound.status;
                    sppFound.arrival_date = (sppData.arrival_date != null) ? sppData.arrival_date : sppFound.arrival_date;

                    mspbu.Entry(sppFound).State = EntityState.Modified;
                }
            }
            return mspbu.SaveChanges();
            //int rowAffected = mspbu.SaveChanges();

            //return rowAffected + " row(s) updated";
        }

        public int sppDelete(int sppId)
        {
            spp sppFound = mspbu.spps.Find(sppId);
            if (sppFound != null)
                mspbu.spps.Remove(sppFound);
            return mspbu.SaveChanges();
            //int rowAffected = mspbu.SaveChanges();

            //return rowAffected + " row deleted";
        }
        public int sppDeleteBatch(List<int> sppIdList)
        {
            //List<int> idListRequest = (List<int>)convertJsonToType(idListRequestJson, typeof(List<int>));
            foreach (int sppId in sppIdList)
            {
                spp sppFound = mspbu.spps.Find(sppId);
                if (sppFound != null)
                    mspbu.spps.Remove(sppFound);
            }
            return mspbu.SaveChanges();
            //int rowAffected = mspbu.SaveChanges();

            //return rowAffected + " row(s) deleted";
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
