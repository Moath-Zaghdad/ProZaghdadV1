using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;


namespace ProZaghdadV1.Models
{
    public class College: FullAuditedEntity<int>
    {
        public College()
        {
            this.CreationTime = DateTime.Now;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        // TODO: check if it is possible to use Point
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ZaghdadString { get; set; }
    }
}
