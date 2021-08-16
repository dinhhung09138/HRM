using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model
{
    public class Grid<T> where T : class
    {
        public long Count { get; set; }
        public IEnumerable<T> List { get; set; }
        public GridParameters Parameters { get; set; }
    }
}
