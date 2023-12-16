﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Dtos
{
    public record Pagination
    {
        public int PageNumber { get; set; } = 0;

        public int PageSize { get; set; } = 10;
    }
}
