﻿using System.Web.Mvc;

namespace WhoWantsToBeAMillionaire
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
