﻿using System.Web;
using System.Web.Mvc;

namespace TASI_APIRecruiment_Entities
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
