﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Recreat.Domain.Core.Base
{
    public abstract class BaseEntity<T> 
    {
        public T Id { get; set; }
    }
}
