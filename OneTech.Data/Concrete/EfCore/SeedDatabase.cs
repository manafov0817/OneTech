using Microsoft.EntityFrameworkCore;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        //public static void Seed ()
        //{
        //    var db = new OneTechDbContext( );
        //    if (db.Database.GetPendingMigrations( ).Count( ) == 0)
        //    {
        //        if (db.Products.Count( ) == 0)
        //        {
        //            db.Products.AddRange(Products);
        //        }
        //        if (db.SubCategories.Count( ) == 0)
        //        {
        //            db.SubCategories.AddRange(SubCategories);
        //        }

        //        db.SaveChanges( ); 
        //    }
        //}


        //private static Product[] Products =
        //{
        //    new Product(){Name="Samsung S5",Price = 2000,ImageUrl="1.jpg",Description="good Phone",IsApproved=true},
        //    new Product(){Name="Samsung S6",Price = 9000,ImageUrl="2.jpg",Description="good Phone",IsApproved=true},
        //    new Product(){Name="Samsung S7",Price = 8000,ImageUrl="3.jpg",Description="good Phone",IsApproved=false},
        //    new Product(){Name="Samsung S8",Price = 6000,ImageUrl="4.jpg",Description="good Phone",IsApproved=true},
        //    new Product(){Name="Samsung S9",Price = 5000,ImageUrl="5.jpg",Description="good Phone",IsApproved=false},
        //    new Product(){Name="Samsung S10",Price = 4000,ImageUrl="6.jpg",Description="good Phone",IsApproved=true},
        //    new Product(){Name="Samsung S20",Price = 3000,ImageUrl="7.jpg",Description="good Phone",IsApproved=true}

        //};

        //private static SubCategory[] SubCategories =
        //{
        //    new SubCategory(){Name = "Smart Phone",Url="smart-phone"},
        //    new SubCategory(){Name = "Home Phone",Url="home-phone"},
        //    new SubCategory(){Name = "Laptops",Url="laptops"},
        //};

    }
}
