using STDemo_SC.DB;
using STDemo_SC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace STDemo_SC.Utility
{
    public class DBAccess
    {
        #region User Controller functions

        public static int InsertUserInfo(User model)
        {
            STDemo_DBEntities db = new STDemo_DBEntities();
            int id = 0;
            try
            {
                var @cmdText = "exec uspInsertUserInfo @Name,@MobileNumber,@Organization,@Address,@EmailAddress,@Location";
                var @Params = new[]{
                                new SqlParameter("Name",model.Name),
                                new SqlParameter("MobileNumber",model.MobileNumber),
                                new SqlParameter("Organization",model.Organization),
                                new SqlParameter("Address",model.Address),
                                new SqlParameter("EmailAddress",model.EmailAddress),
                                new SqlParameter("Location",model.Location)
                            };

                db.Database.CommandTimeout = 0;
                id = db.Database.ExecuteSqlCommand(@cmdText, @Params);
            }
            catch (Exception ex)
            {
                
            }
            return id;
        }

        public static List<UpdatedUserData> UpdateUserInfo(User model)
        {
            STDemo_DBEntities db = new STDemo_DBEntities();           
            List<UpdatedUserData> odata = null;
            string Name = "", MobileNumber = "", Organization = "", Address = "", EmailAddress = "", Location = "";           
            if (model.Name != null)
                Name = model.Name;
            if (model.MobileNumber != null)
                MobileNumber = model.MobileNumber;
            if (model.Organization != null)
                Organization = model.Organization;
            if (model.Address != null)
                Address = model.Address;
            if (model.EmailAddress != null)
                EmailAddress = model.EmailAddress;          
            if (model.Location != null)
                Location = model.Location;          
            try
            {
                var @cmdText = "exec uspUpdateUserInfo @UserID,@Name,@MobileNumber,@Organization,@Address,@EmailAddress,@Location";
                var @Params = new[]{
                                new SqlParameter("UserID",model.UserID),
                                new SqlParameter("Name",model.Name),
                                new SqlParameter("MobileNumber",model.MobileNumber),
                                new SqlParameter("Organization",model.Organization),
                                new SqlParameter("Address",model.Address),
                                new SqlParameter("EmailAddress",model.EmailAddress),
                                new SqlParameter("Location",model.Location)
                            };

                db.Database.CommandTimeout = 0;
                odata = db.Database.SqlQuery<UpdatedUserData>(@cmdText, @Params).ToList<UpdatedUserData>();
                
            }
            catch (Exception ex)
            {

            }
            return odata;
        }
        #endregion User Controller functions       
 
        #region Vehicle Controller functions

        public static int InsertVehicleInfo(Vehicle model)
        {
            STDemo_DBEntities db = new STDemo_DBEntities();
            int id = 0;
            try
            {
                var @cmdText = "exec uspInsertVehicleInfo @VehicleType ,@ChassisNumber,@EngineNumber,@ManufacturingYear,@LoadCarryingCapacity,@MakeOfVehicle,@ModelNumber,@BodyType,@OrganizationName,@DeviceID,@UserID";
                var @Params = new[]{
                                new SqlParameter("VehicleType",model.VehicleType),
                                new SqlParameter("ChassisNumber",model.ChassisNumber),
                                new SqlParameter("EngineNumber",model.EngineNumber),
                                new SqlParameter("ManufacturingYear",model.ManufacturingYear),
                                new SqlParameter("LoadCarryingCapacity",model.LoadCarryingCapacity),
                                new SqlParameter("MakeOfVehicle",model.MakeOfVehicle),
                                new SqlParameter("ModelNumber",model.ModelNumber),
                                new SqlParameter("BodyType",model.BodyType),
                                new SqlParameter("OrganizationName",model.OrganizationName),
                                new SqlParameter("DeviceID",model.DeviceID),
                                new SqlParameter("UserID",model.UserID),
                            };

                db.Database.CommandTimeout = 0;
                id = db.Database.ExecuteSqlCommand(@cmdText, @Params);
            }
            catch (Exception ex)
            {

            }
            return id;
        }
        public static List<VehicleData> SearchVehicleDetails(string VehicleType)
        {
            STDemo_DBEntities db = new STDemo_DBEntities();
            List<VehicleData> oData = new List<VehicleData>();

            if (VehicleType == null)
            {
                VehicleType = "";
            }

            try
            {
                var @cmdText = "exec uspSearchVehicleInfo @VehicleType";
                var @Params = new[]{                                  
                                new SqlParameter("VehicleType",VehicleType)                            
                            };
                db.Database.CommandTimeout = 0;
                oData = db.Database.SqlQuery<VehicleData>(@cmdText, @Params).ToList<VehicleData>();
            }

            catch (Exception ex)
            {
               
            }
            return oData;

        }
        #endregion Vehicle Controller functions
    }
}