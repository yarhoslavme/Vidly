﻿namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public short SignUpFree { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}