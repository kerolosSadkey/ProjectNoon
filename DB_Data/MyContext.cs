using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=Noon")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
    }
}
