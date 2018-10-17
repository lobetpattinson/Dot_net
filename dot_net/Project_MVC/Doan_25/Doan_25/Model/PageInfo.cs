using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan_25.Model
{
    public class PageInfo<T>
    {
        public int CurrentPage { get; set; }
        public int pageCount { get; set; }
        public List<T> ListItem { get; set; }
        public int pageSize { get; set; }
    }
}
