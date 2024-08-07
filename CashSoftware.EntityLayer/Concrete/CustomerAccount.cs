﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashSoftware.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountId { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set;}
        public decimal CustomerAccountBalance { get; set;}
        public string BankBranch { get;set;}
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
