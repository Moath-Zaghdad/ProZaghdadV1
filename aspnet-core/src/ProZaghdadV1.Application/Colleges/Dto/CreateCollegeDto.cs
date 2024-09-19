using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Colleges.Dto
{
    [AutoMapTo(typeof(College))]
    public class CreateCollegeDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ZaghdadString { get; set; }

    }
}
