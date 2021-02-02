using Microsoft.EntityFrameworkCore;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTech.Data.Concrete.EfCore
{
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem, OneTechDbContext>, ICartItemRepository
    {
        public List<CartItem> GetByCartId ( int id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.CartItems
                                    .Where(ci => ci.CartId == id)
                                    .Include(ci=>ci.Product)
                                        .ThenInclude(p => p.ProductPhotos)
                                                .ThenInclude(pp => pp.Photo)
                                    .Include(ci => ci.Product)
                                        .ThenInclude(p => p.ProductSubCategories)
                                                .ThenInclude(ps => ps.SubCategory)
                                                    .ThenInclude(s => s.Category)
                                                        .ThenInclude(c => c.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductCategories)
                                                .ThenInclude(pc => pc.Category)
                                                    .ThenInclude(c => c.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductMainCategories)
                                                .ThenInclude(pmc => pmc.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductOptionValues)
                                                .ThenInclude(pov => pov.OptionValue)
                                                    .ThenInclude(ov => ov.Option)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductRelate)
                                                    .ThenInclude(pr => pr.Relate)
                                    .ToList( );
            }
        }

        public List<CartItem> GetByUserId ( string id )
        {
            using (var context = new OneTechDbContext( ))
            {
                return context.CartItems
                                    .Include(ci=>ci.Cart)
                                    .Where(ci=>ci.Cart.UserId==id)
                                    .Include(ci=>ci.Product)
                                        .ThenInclude(p => p.ProductPhotos)
                                                .ThenInclude(pp => pp.Photo)
                                    .Include(ci => ci.Product)
                                        .ThenInclude(p => p.ProductSubCategories)
                                                .ThenInclude(ps => ps.SubCategory)
                                                    .ThenInclude(s => s.Category)
                                                        .ThenInclude(c => c.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductCategories)
                                                .ThenInclude(pc => pc.Category)
                                                    .ThenInclude(c => c.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductMainCategories)
                                                .ThenInclude(pmc => pmc.MainCategory)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductOptionValues)
                                                .ThenInclude(pov => pov.OptionValue)
                                                    .ThenInclude(ov => ov.Option)
                                    .Include(ci => ci.Product)
                                            .ThenInclude(p => p.ProductRelate)
                                                    .ThenInclude(pr => pr.Relate)
                                    .ToList( );
            }
        }
    }
}
