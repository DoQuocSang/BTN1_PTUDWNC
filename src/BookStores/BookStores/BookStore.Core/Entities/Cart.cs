﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities
{
    public class Cart
    {
        
        public string Id { get; set; }
          // Danh sách sản phẩm
        public IList<Book> Books { get; set; }

    }
}
