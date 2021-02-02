using Microsoft.EntityFrameworkCore;
using OneTech.Entity.ComponentModels;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed ()
        {
            var db = new OneTechDbContext( );
            List<Product> discountedProducts = db.Products
                                                    .Where(p => p.DiscountWithMoney > 0 || p.DiscountWithPercent > 0)
                                                    .ToList( );

            foreach (Product product in discountedProducts)
            {
                if (DateTime.Now.Subtract(Convert.ToDateTime(product.DiscountEnd)).TotalMilliseconds >= 0)
                {
                    Product deleteDiscount = db.Products.Where(p => p.Id == product.Id).FirstOrDefault( );
                    
                    
                    DealOfWeekProduct dealOfWeekProduct = db.DealOfWeekProducts.Where(dow => dow.ProductId == product.Id).FirstOrDefault( );


                    db.DealOfWeekProducts.Remove(dealOfWeekProduct);
                    deleteDiscount.DiscountWithMoney = null;
                    deleteDiscount.DiscountWithPercent = null;
                    deleteDiscount.DiscountStart = null;
                    deleteDiscount.DiscountEnd = null;
                }
            }

            db.SaveChanges( );

        }
    }
}
