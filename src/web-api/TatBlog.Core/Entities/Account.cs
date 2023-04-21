﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Contracts;

namespace TatBlog.Core.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string NameAccount { get; set; }
        public string EmailAccount { get; set; }
        public string Pass { get; set; }
        public bool Type { get; set; }
    }

}

