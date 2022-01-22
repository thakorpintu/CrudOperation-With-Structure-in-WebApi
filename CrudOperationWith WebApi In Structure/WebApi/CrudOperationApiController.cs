using BusinessLayer.Entity;
using CrudOperationWith_WebApi_In_Structure.Models;
using DataLayer.InterFace;
using DataLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CrudOperationWith_WebApi_In_Structure.WebApi
{
    public class CrudOperationApiController : ApiController
    {

        private CrudOperationI _user;

        public CrudOperationApiController()
        {
            _user = new CrudOperationService();
        }


        [System.Web.Http.Route("api/CrudOperationApi/Index")]
        [System.Web.Http.HttpGet]
        public List<UserMaster> Index()
        {
            try
            {
                return _user.ShowData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [System.Web.Http.Route("api/CrudOperationApi/Edit")]
        [System.Web.Http.HttpPost]
        public UserMaster Edit(UserMaster model)
        {
            try
            {
                return _user.Edit(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [System.Web.Http.Route("api/CrudOperationApi/Delete")]
        [System.Web.Http.HttpPost]
        public int Delete(UserMaster model)
        {
            try
            {
                return _user.Delete(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [System.Web.Http.Route("api/CrudOperationApi/SaveData")]
        [System.Web.Http.HttpPost]
        public int SaveData()
        {
            UserMaster master = new UserMaster();
            try
            {
                var UserDetails = HttpContext.Current.Request;


                if (Convert.ToInt32(UserDetails["Id"]) > 0)
                {
                    master.Id = Convert.ToInt32(UserDetails["Id"]);
                    master.Name = Convert.ToString(UserDetails["Name"]);
                    master.Email = Convert.ToString(UserDetails["Email"]);
                    master.Password = Convert.ToString(UserDetails["Password"]);
                    master.Mobile = Convert.ToString(UserDetails["Mobile"]);
                    master.Rdate = DateTime.UtcNow;

                    if (UserDetails.Files.Count > 0)
                    {
                        foreach (string item in UserDetails.Files)
                        {
                            var postfiles = UserDetails.Files[item];
                            postfiles.SaveAs(HttpContext.Current.Server.MapPath("~/Images/" + postfiles.FileName));
                            master.Image = "~/Images/" + postfiles.FileName;
                        }
                    }
                    else
                    {
                        master.Image = Convert.ToString(UserDetails["Image"]);
                    }
                    _user.CrudOperation(master);

                }
                else
                {
                    master.Name = Convert.ToString(UserDetails["Name"]);
                    master.Email = Convert.ToString(UserDetails["Email"]);
                    master.Password = Convert.ToString(UserDetails["Password"]);
                    master.Mobile = Convert.ToString(UserDetails["Mobile"]);
                    master.Rdate = DateTime.UtcNow;

                    if (UserDetails.Files.Count > 0)
                    {
                        foreach (string item in UserDetails.Files)
                        {
                            var postfiles = UserDetails.Files[item];
                            postfiles.SaveAs(HttpContext.Current.Server.MapPath("~/Images/" + postfiles.FileName));
                            master.Image = "~/Images/" + postfiles.FileName;
                        }
                    }
                    _user.CrudOperation(master);


                }




            }
            catch (Exception ex)
            {

                throw ex;
            }

            return 0;
        }
    }
}