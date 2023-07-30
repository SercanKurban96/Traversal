﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.EntityLayer.Concrete;

namespace Traversal.DataAccessLayer.EntityFramework
{
    public class EfAccountDAL : RepositoryUoWDAL<Account>, IAccountDAL
    {
        public EfAccountDAL(Context context) : base(context)
        {

        }
    }
}
