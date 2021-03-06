﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MasterDetail.Models
{
    public interface IWorkListItems
    {
        int Id { get; }
        string Description { get; set; }
        string Status { get; }

        [Display(Name = "User")]
        string CurrentWorkerName { get; }

        [Display(Name = "Entity")]
        string EntityFamiliarName { get; }

        [Display(Name = "Entity")]
        string EntityFamiliarNamePlural { get; }

        [Display(Name = "Entity")]
        string EntityFormalName { get; }

        [Display(Name = "Entity")]
        string EntityFormalNamePlural { get; }

        [Display(Name = "Priority Score")]
        int PriorityScore { get; }
        IEnumerable<string> RolesWhichCanClaim { get; }

        PromotionResult ClaimWorkListItem(string userId);
        PromotionResult PromoteWorkListItem(string command);
        PromotionResult RelinquishWorkListItem();
    }
}