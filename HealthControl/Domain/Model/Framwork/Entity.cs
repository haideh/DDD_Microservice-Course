﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Framwork
{
    public class Entity<TKey>
    {
        public TKey Id { get; protected set; }
    }
}
