﻿using ProjectCoreDDD.Domain.Entities;
using System;

namespace ProjectCoreDDD.Application.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime LastPurchase { get; set; }

        public int GenderId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public int ClassificationId { get; set; }
        public int UserId { get; set; }

        public Gender Gender { get; set; }
        public City City { get; set; }
        public Region Region { get; set; }
        public Classification Classification { get; set; }

        // SELLER
        public UserSys User { get; set; }
    }
}