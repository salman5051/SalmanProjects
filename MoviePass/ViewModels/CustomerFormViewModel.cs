﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoviePass.Models;

namespace MoviePass.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
    }
}