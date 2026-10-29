using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class StoreDB2 : DbContext
    {
        public StoreDB2() : base(@"name=StoreDB2") { }
        public DbSet<Products> Products { get; set; }
    }
}
