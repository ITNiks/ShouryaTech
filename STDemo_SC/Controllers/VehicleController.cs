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
    [RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {
        STDemo_DBEntities db = new STDemo_DBEntities();

        [Route("addnewvehicle")]
        [HttpPost]
        public HttpResponseMessage RegisterNewUser(Vehicle model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int i = DBAccess.InsertVehicleInfo(model);
                    if (i > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Success", Message = "Vehicle details added successfully!" });
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while adding Vehicle details. Please try again." });
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", message = "Error occurred while adding Vehicle details. Please try again." });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", Message = "Error occurred while adding Vehicle details. Please try again." });
            }
        }
       
        [Route("findvehicle")]
        [HttpGet]
        public HttpResponseMessage SearchTeam(string VehicleType)
        {
            try
            {
                List<VehicleData> oData = DBAccess.SearchVehicleDetails(VehicleType);

                if (oData.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = "Success", message = "User searching vehicle details successfully", VehicleDetails = oData });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", message = "Invalid searching vehicle details" });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, new { result = "Fail", message = "Invalid searching vehicle details" });
            }


        }    
    }
}
