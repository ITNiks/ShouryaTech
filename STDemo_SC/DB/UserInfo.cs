//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STDemo_SC.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.VehicleInfoes = new HashSet<VehicleInfo>();
        }
    
        public int UserID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ICollection<VehicleInfo> VehicleInfoes { get; set; }
    }
}
