//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_Service.Model
{
    using System;
    using System.Collections.Generic;

    public partial class spp
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string police_no { get; set; }
        public string shipment_no { get; set; }
        public Nullable<double> volume { get; set; }
        public string dens_temp { get; set; }
        public string buyer { get; set; }
        public string product { get; set; }
        public Nullable<System.DateTime> print_date { get; set; }
        public Nullable<System.DateTime> verification_date { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> arrival_date { get; set; }
    }
}
