﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SuperProfessor
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();
        }
    }
}
