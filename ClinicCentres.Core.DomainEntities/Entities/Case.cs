﻿using System;
using System.Collections.Generic;

namespace ClinicCentres.Core.DomainEntities
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
