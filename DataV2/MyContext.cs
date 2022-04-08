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
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Images> Image { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderSummary> OrderSummary { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
    }
}
