﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    internal static class WordAppServiceProvider
    {
        private static IServiceProvider _serviceProvider;

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static IServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException("Service provider is not set.");
            }
            return _serviceProvider;
        }
    }
}
