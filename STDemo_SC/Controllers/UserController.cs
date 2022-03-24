using STDemo_SC.DB;
using STDemo_SC.Models;
using STDemo_SC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STDemo_SC.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        STDemo_DBEntities db = new STDemo_DBEntities();

        [Route("addnewuser")]
        [HttpPost]
        public HttpResponseMessage RegisterNewUser(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int i = DBAccess.InsertUserInfo(model);
                    if (i > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Success", Message = "User details added successfully!" });
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while adding user details. Please try again." });
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", message = "Error occurred while adding user details. Please try again." });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while adding user details. Please try again." });
            }
        }

        [Route("updatenewuser")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(User model)
     {
            try
            {
                if (ModelState.IsValid)
                {
                    List<UpdatedUserData> oData = DBAccess.UpdateUserInfo(model);
                    if (oData.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Success", Message = "User details update successfully!" });
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while updating user details. Please try again." });
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", message = "Error occurred while updating user details. Please try again." });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while updating user details. Please try again." });
            }
        }
    }
}

