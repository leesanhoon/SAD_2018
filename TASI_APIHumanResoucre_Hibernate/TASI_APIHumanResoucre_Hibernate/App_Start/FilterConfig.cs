﻿using System.Web;
using System.Web.Mvc;

namespace TASI_APIHumanResoucre_Hibernate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
