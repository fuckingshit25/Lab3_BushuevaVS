namespace Лаб3
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TriangleDBEntities : System.Data.Entity.DbContext
    {
        public TriangleDBEntities()
            : base("name=TriangleDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public System.Data.Entity.DbSet<Triangle> Triangle { get; set; }
    }
}
