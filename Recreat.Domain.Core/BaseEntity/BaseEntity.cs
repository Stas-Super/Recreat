using System;
using System.Collections.Generic;
using System.Text;

namespace Recreat.Domain.Core.BaseEntity
{
    public class BaseEntity<T>
        where T : struct
    {
        public T Id { get; set; }
    }
}
