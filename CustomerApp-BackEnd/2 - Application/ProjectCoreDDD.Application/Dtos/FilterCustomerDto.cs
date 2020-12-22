
using System;

namespace ProjectCoreDDD.Application.Dtos
{
    public class FilterCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int ClassificationId { get; set; }
        public int UserId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
