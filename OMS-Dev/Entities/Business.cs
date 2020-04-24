using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using OMS_Dev.Models;

namespace OMS_Dev.Entities
{
    public class Business
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? Incorporation { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public int IndustryId { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Industry Industry { get; set; }
    }
}