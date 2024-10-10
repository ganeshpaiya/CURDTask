﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class APIError
    {
        public string Description { get; set; }

        public APIError(string description)
        {
            Description = description;
        }
    }
}
