﻿using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;

namespace ProZaghdadV1.Authorization.Accounts.Dto
{
    public class IsTenantAvailableInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
