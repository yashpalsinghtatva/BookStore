using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookStoreAPI.Data
{
    public class BookStoreContext : DbContext
    {

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<ShippingMethod> ShippingMethods{ get; set; }
        public DbSet<OrderStatus> OrderStatuses{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderBook> OrderBooks{ get; set; }
    }
}
