using System;
using System.Collections.Generic;

namespace CompuqWebAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public int PhoneNumber { get; set; }

    public string? PhoneMake { get; set; }

    public string? PhoneMonthlypay { get; set; }

    public string? PhonePlanMonthlypay { get; set; }
}
