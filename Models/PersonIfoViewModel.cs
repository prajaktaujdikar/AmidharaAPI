using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmidharaAPI.Models
{
    public class PersonIfoViewModel
    {
        public long RegistrationID { get; set; }
        public string FamilyCode { get; set; }
        public string PersonName { get; set; }
        public string GPersonName { get; set; }
        public string PAddress { get; set; }
        public string PGAddress { get; set; }
        public string MobileNo { get; set; }
        public string Photo { get; set; }

    }
}