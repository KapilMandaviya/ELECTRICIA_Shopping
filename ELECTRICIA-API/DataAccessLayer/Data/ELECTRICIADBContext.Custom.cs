
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public partial class ELECTRICIADBContext
    {
        public virtual DbSet<BlogDetailDTO> BlogDetailDTO { get; set; }
        public virtual DbSet<SPCategoryList> SPCategoryList { get; set; }
        public virtual DbSet<SPProdcutCategoryList> SPProdcutCategoryList { get; set; }
        public virtual DbSet<SP_GET_TOPDiscountProduct> SP_GET_TOPDiscountProducts { get; set; }
        public virtual DbSet<SP_GET_TopFeauteredProduct> SP_GET_TopFeauteredProducts { get; set; }
        public virtual DbSet<SP_GET_TopNewArrivalProduct> SP_GET_TopNewArrivalProducts { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogDetailDTO>().HasNoKey().ToView(null); // No table mapping, just for queries
            modelBuilder.Entity<SPCategoryList>().HasNoKey().ToView(null); // No table mapping, just for queries
            modelBuilder.Entity<SPProdcutCategoryList>().HasNoKey().ToView(null); // No table mapping, just for queries
            modelBuilder.Entity<SP_GET_TOPDiscountProduct>().HasNoKey().ToView(null); // No table mapping, just for queries
            modelBuilder.Entity<SP_GET_TopFeauteredProduct>().HasNoKey().ToView(null); // No table mapping, just for queries
            modelBuilder.Entity<SP_GET_TopNewArrivalProduct>().HasNoKey().ToView(null); // No table mapping, just for queries
        }
    }
}
