using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneTech.Business.Abstract;
using OneTech.Data.Concrete.EfCore;
using OneTech.Entity.Models;
using OneTech.WebUi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OneTech.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IOptionService _optionService;
        private readonly IOptionValueService _optionValueService;
        private readonly IBrandModelService _brandModelService;
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly IPhotoService _photoService;


        private readonly IProductOptionValueService _productOptionValueService;
        private readonly IProductPhotoService _productPhotoService;
        private readonly IProductMainCategoryService _productMainCategoryService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductSubCategoryService _productSubCategoryService;
        public ProductController ( ICategoryService categoryService,
                                   ISubCategoryService subCategoryService,
                                   IMainCategoryService mainCategoryService,
                                   IOptionService optionService,
                                   IOptionValueService optionValueService,
                                   IBrandModelService brandModelService,
                                   IBrandService brandService,
                                   IProductService productService,
                                   IPhotoService photoService,


                                   IProductOptionValueService productOptionValueService,
                                   IProductPhotoService productPhotoService,
                                   IProductMainCategoryService productMainCategoryService,
                                   IProductCategoryService productCategoryService,
                                   IProductSubCategoryService productSubCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mainCategoryService = mainCategoryService;
            _optionService = optionService;
            _optionValueService = optionValueService;
            _productService = productService;
            _brandModelService = brandModelService;
            _brandService = brandService;
            _photoService = photoService;


            _productOptionValueService = productOptionValueService;
            _productPhotoService = productPhotoService;
            _productMainCategoryService = productMainCategoryService;
            _productCategoryService = productCategoryService;
            _productSubCategoryService = productSubCategoryService;
        }

        public IActionResult Index ()
        {
            return View(_productService.GetProductWithCategoryTypes( ));
        }

        public IActionResult Create ()
        {
            ViewBag.Options = _optionService.GetAll( );
            ViewBag.Brands = _brandService.GetAll( );

            ViewBag.MainCategories = _mainCategoryService.GetAll( );
            ViewBag.Colors = _optionValueService.GetAllColors( );
            return View( );
        }
        [HttpPost]
        public IActionResult Create ( ProductModel model )
        {
            if (ModelState.IsValid)
            {
                Product product = new Product( )
                {
                    Name = model.Name,
                    Description = model.Description,
                    BrandModelId = model.BrandModelId,
                    PurchasePrice = model.PurchasePrice,
                    SellingPrice = model.SellingPrice,
                    Status = false,
                    AddedDate = DateTime.Now,
                    Quantity = model.Quantity,
                };

                _productService.Create(product);

                if (model.SubCategoryIds != null)
                {
                    if (model.SubCategoryIds.Count( ) > 0)
                    {
                        foreach (int subCategoryId in model.SubCategoryIds)
                        {
                            ProductSubCategory productSubCategory = new ProductSubCategory( )
                            {
                                ProductId = product.Id,
                                SubCategoryId = subCategoryId
                            };
                            _productSubCategoryService.Create(productSubCategory);
                        }
                    }
                }

                if (model.CategoryIds.Count( ) > 0)
                {
                    foreach (int categoryId in model.CategoryIds)
                    {
                        int counter = 0;
                        if (model.SubCategoryIds != null)
                        {
                            foreach (int subCategoryId in model.SubCategoryIds)
                            {
                                SubCategory subCategory = _subCategoryService.GetSubCategoryWithCategoryAndMainCategorybyId(subCategoryId);
                                if (subCategory.CategoryId == categoryId)
                                {
                                    counter++;
                                }
                            }
                        }
                        if (counter == 0)
                        {
                            ProductCategory productCategory = new ProductCategory( )
                            {
                                ProductId = product.Id,
                                CategoryId = categoryId
                            };
                            _productCategoryService.Create(productCategory);
                        }
                    }
                }

                if (model.MainCategoryIds.Count( ) > 0)
                {
                    foreach (int mainCategoryId in model.MainCategoryIds)
                    {
                        int counter = 0;
                        if (model.SubCategoryIds != null)
                        {
                            foreach (int subCategoryId in model.SubCategoryIds)
                            {
                                SubCategory subCategory = _subCategoryService.GetSubCategoryWithCategoryAndMainCategorybyId(subCategoryId);
                                if (subCategory.Category.MainCategoryId == mainCategoryId)
                                {
                                    counter++;
                                }
                            }
                        }

                        if (model.CategoryIds != null)
                        {
                            foreach (int categoryId in model.CategoryIds)
                            {
                                Category category = _categoryService.GetCategoryWithMainCategoryById(categoryId);
                                if (category.MainCategoryId == mainCategoryId)
                                {
                                    counter++;
                                }
                            }
                        }
                        if (counter == 0)
                        {
                            ProductMainCategory productMainCategory = new ProductMainCategory( )
                            {
                                ProductId = product.Id,
                                MainCategoryId = mainCategoryId
                            };
                            _productMainCategoryService.Create(productMainCategory);
                        };
                    }
                }

                foreach (int optionValueId in model.OptionValueIds)
                {
                    ProductOptionValue productOptionValue = new ProductOptionValue( )
                    {
                        ProductId = product.Id,
                        OptionValueId = optionValueId,
                    };
                    _productOptionValueService.Create(productOptionValue);
                }

                ProductOptionValue color = new ProductOptionValue( )
                {
                    ProductId = product.Id,
                    OptionValueId = model.ColorId,
                };

                _productOptionValueService.Create(color);

                foreach (var photo in model.Photos)
                {
                    var extension = Path.GetExtension(photo.FileName);
                    var randomName = string.Format($"{Guid.NewGuid( )}{extension}");

                    string path = Path.Combine(Directory.GetCurrentDirectory( )
                                                                , "wwwroot", "img", "Products"
                                                                , randomName);

                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        photo.CopyTo(fs);
                    }

                    Photo newPhoto = new Photo( )
                    {
                        Path = randomName
                    };
                    _photoService.Create(newPhoto);

                    ProductPhoto productPhoto = new ProductPhoto( )
                    {
                        PhotoId = newPhoto.Id,
                        ProductId = product.Id,
                    };
                    _productPhotoService.Create(productPhoto);
                }
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Options = _optionService.GetAll( );
            ViewBag.Brands = _brandService.GetAll( );
            ViewBag.MainCategories = _mainCategoryService.GetAll( );
            ViewBag.Colors = _optionValueService.GetAllColors( );
            return View(model);
        }

        public IActionResult Edit ( int productId )
        {
            if (productId != 0)
            {
                Product product = _productService.GetProductWithEverythingById(productId);
                ProductEditModel model = new ProductEditModel( )
                {
                    Id = productId,
                    Name = product.Name,
                    PurchasePrice = (decimal)product.PurchasePrice,
                    SellingPrice = (decimal)product.SellingPrice,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    BrandModelId = product.BrandModelId,
                };

                ViewBag.Options = _optionService.GetAll( );
                ViewBag.Brands = _brandService.GetAll( );
                ViewBag.BrandId = _brandModelService.GetById(product.BrandModelId).BrandId;
                ViewBag.MainCategories = _mainCategoryService.GetAll( );
                ViewBag.Colors = _optionValueService.GetAllColors( );

                return View(model);
            }
            return View(productId);
        }
        [HttpPost]
        public async Task<IActionResult> Edit ( ProductEditModel model )
        {
            if (ModelState.IsValid)
            {
                Product editingProduct = _productService.GetProductWithEverythingById(model.Id);
                editingProduct.Name = model.Name;
                editingProduct.Description = model.Description;
                editingProduct.BrandModelId = model.BrandModelId;
                editingProduct.PurchasePrice = model.PurchasePrice;
                editingProduct.SellingPrice = model.SellingPrice;
                editingProduct.Quantity = model.Quantity;

                if (editingProduct.ProductMainCategories.Count( ) > 0)
                {
                    foreach (ProductMainCategory productMainCategory in editingProduct.ProductMainCategories.ToList( ))
                    {
                        _productMainCategoryService.Delete(productMainCategory);
                    }
                }

                if (editingProduct.ProductCategories.Count( ) > 0)
                {
                    foreach (ProductCategory productCategory in editingProduct.ProductCategories.ToList( ))
                    {
                        _productCategoryService.Delete(productCategory);
                    }
                }

                if (editingProduct.ProductSubCategories.Count( ) > 0)
                {
                    foreach (ProductSubCategory productSubCategory in editingProduct.ProductSubCategories.ToList( ))
                    {
                        _productSubCategoryService.Delete(productSubCategory);
                    }
                }

                if (model.SubCategoryIds.Count( ) > 0)
                {
                    foreach (int subCategoryId in model.SubCategoryIds)
                    {
                        ProductSubCategory productSubCategory = new ProductSubCategory( )
                        {
                            ProductId = model.Id,
                            SubCategoryId = subCategoryId
                        };
                        _productSubCategoryService.Create(productSubCategory);
                    }
                }

                if (model.CategoryIds.Count( ) > 0)
                {
                    foreach (int categoryId in model.CategoryIds)
                    {
                        int counter = 0;
                        foreach (int subCategoryId in model.SubCategoryIds.ToList( ))
                        {
                            SubCategory subCategory = _subCategoryService.GetSubCategoryWithCategoryAndMainCategorybyId(subCategoryId);
                            if (subCategory.CategoryId != categoryId)
                            {
                                counter++;
                            }
                        }
                        if (counter != 0)
                        {
                            ProductCategory productCategory = new ProductCategory( )
                            {
                                ProductId = model.Id,
                                CategoryId = categoryId
                            };
                            _productCategoryService.Create(productCategory);
                        }
                    }
                }

                if (model.MainCategoryIds.Count( ) > 0)
                {
                    foreach (int mainCategoryId in model.MainCategoryIds.ToList( ))
                    {
                        int counter = 0;
                        foreach (int subCategoryId in model.SubCategoryIds)
                        {
                            SubCategory subCategory = _subCategoryService.GetSubCategoryWithCategoryAndMainCategorybyId(subCategoryId);
                            if (subCategory.Category.MainCategoryId != mainCategoryId)
                            {
                                counter++;
                            }
                        }

                        foreach (int categoryId in model.CategoryIds)
                        {
                            Category category = _categoryService.GetCategoryWithMainCategoryById(categoryId);
                            if (category.MainCategoryId != mainCategoryId)
                            {
                                counter++;
                            }
                        }
                        if (counter != 0)
                        {
                            ProductMainCategory productMainCategory = new ProductMainCategory( )
                            {
                                ProductId = model.Id,
                                MainCategoryId = mainCategoryId
                            };
                            _productMainCategoryService.Create(productMainCategory);
                        };
                    }
                }

                if (editingProduct.ProductOptionValues.Count( ) > 0)
                {
                    foreach (ProductOptionValue productOptionValue in editingProduct.ProductOptionValues.ToList( ))
                    {
                        _productOptionValueService.Delete(productOptionValue);
                    }
                };

                foreach (int optionValueId in model.OptionValueIds)
                {
                    ProductOptionValue productOptionValue = new ProductOptionValue( )
                    {
                        ProductId = model.Id,
                        OptionValueId = optionValueId,
                    };
                    _productOptionValueService.Create(productOptionValue);
                }

                ProductOptionValue color = new ProductOptionValue( )
                {
                    ProductId = model.Id,
                    OptionValueId = model.ColorId,
                };

                _productOptionValueService.Create(color);

                if (editingProduct.ProductPhotos.Count( ) > 0)
                {
                    foreach (var photo in editingProduct.ProductPhotos.ToList( ))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory( ),
                                                                      "wwwroot", "img", "Products"
                                                                   , photo.Photo.Path);

                        FileInfo fi = new FileInfo(oldPath);
                        if (fi != null)
                        {
                            System.IO.File.Delete(photo.Photo.Path);
                            fi.Delete( );
                        }
                        _productPhotoService.Delete(photo);
                    }
                }

                foreach (var photo in model.Photos)
                {
                    var extension = Path.GetExtension(photo.FileName);
                    var randomName = string.Format($"{Guid.NewGuid( )}{extension}");
                    string path = Path.Combine(Directory.GetCurrentDirectory( )
                                                                , "wwwroot", "img", "Products"
                                                                , randomName);

                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        await photo.CopyToAsync(fs);
                    }

                    Photo newPhoto = new Photo( )
                    {
                        Path = randomName
                    };
                    _photoService.Create(newPhoto);

                    ProductPhoto productPhoto = new ProductPhoto( )
                    {
                        PhotoId = newPhoto.Id,
                        ProductId = model.Id,
                    };
                    _productPhotoService.Create(productPhoto);
                }
                _productService.Update(editingProduct);
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Options = _optionService.GetAll( );
            ViewBag.Brands = _brandService.GetAll( );
            ViewBag.MainCategories = _mainCategoryService.GetAll( );
            ViewBag.Colors = _optionValueService.GetAllColors( );
            return View(model);
        }
        public IActionResult Delete ( int productId )
        {
            if (ModelState.IsValid)
            {
                Product deletingProduct = _productService.GetProductWithEverythingById(productId);

                if (deletingProduct.ProductMainCategories.Count( ) > 0)
                {
                    foreach (ProductMainCategory productMainCategory in deletingProduct.ProductMainCategories.ToList( ))
                    {
                        _productMainCategoryService.Delete(productMainCategory);
                    }
                }

                if (deletingProduct.ProductCategories.Count( ) > 0)
                {
                    foreach (ProductCategory productCategory in deletingProduct.ProductCategories.ToList( ))
                    {
                        _productCategoryService.Delete(productCategory);
                    }
                }

                if (deletingProduct.ProductSubCategories.Count( ) > 0)
                {
                    foreach (ProductSubCategory productSubCategory in deletingProduct.ProductSubCategories.ToList( ))
                    {
                        _productSubCategoryService.Delete(productSubCategory);
                    }
                }

                if (deletingProduct.ProductOptionValues.Count( ) > 0)
                {
                    foreach (ProductOptionValue productOptionValue in deletingProduct.ProductOptionValues.ToList( ))
                    {
                        _productOptionValueService.Delete(productOptionValue);
                    }
                };

                if (deletingProduct.ProductPhotos.Count( ) > 0)
                {
                    foreach (var photo in deletingProduct.ProductPhotos.ToList( ))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory( ),
                                                                      "wwwroot", "img", "Products"
                                                                   , photo.Photo.Path);

                        FileInfo fi = new FileInfo(oldPath);
                        if (fi != null)
                        {
                            System.IO.File.Delete(photo.Photo.Path);
                            fi.Delete( );
                        }
                        _productPhotoService.Delete(photo);
                    }
                }

                _productService.Delete(deletingProduct);

                return RedirectToAction("Index", "Product");
            }
            return View(productId);
        }
        public IActionResult Detail ( int productId )
        {
            return View(_productService.GetProductForDetailById(productId));
        }


        public IActionResult DiscountList ()
        {
            return View(_productService.GetAllDiscountedProducts( ));
        }
        public IActionResult CreateDiscount ( string discountType, int productId )
        {
            if (discountType == "percent")
            {
                Product product = _productService.GetById(productId);
                ProductForDiscount model = new ProductForDiscount( )
                {
                    ProductId = productId,
                    DiscountType = 1,
                    SellingPrice = product.SellingPrice,
                    DiscountWithPercent = product.DiscountWithPercent
                };
                return View(model);
            }
            if (discountType == "money")
            {
                Product product = _productService.GetById(productId);
                ProductForDiscount model = new ProductForDiscount( )
                {
                    ProductId = productId,
                    DiscountType = 0,
                    SellingPrice = product.SellingPrice,
                    DiscountWithMoney = product.DiscountWithMoney
                };
                return View(model);
            }
            return View( );
        }
        [HttpPost]
        public IActionResult CreateDiscount ( ProductForDiscount model )
        {
            if (model.DiscountWithMoney != 0 || model.DiscountWithPercent != 0)
            {
                Product product = _productService.GetById(model.ProductId);

                if (model.DiscountWithMoney != 0)
                {
                    product.DiscountWithMoney = model.DiscountWithMoney;
                }

                if (model.DiscountWithPercent != 0)
                {
                    product.DiscountWithPercent = model.DiscountWithPercent;
                }

                product.DiscountStart = Convert.ToString(model.DiscountStarts);
                product.DiscountEnd = Convert.ToString(model.DiscountEnds);

                _productService.Update(product);

                return RedirectToAction("DiscountList", "Product");
            }
            return View(model);
        }
        public IActionResult RemoveDiscount ( int productId )
        {
            if (productId != 0)
            {
                Product product = _productService.GetById(productId);
                product.DiscountStart = null;
                product.DiscountEnd = null;
                product.DiscountWithMoney = null;
                product.DiscountWithPercent = null;
                _productService.Update(product);
                return RedirectToAction("DiscountList", "Product");
            }
            return View( );
        }
        [HttpPost]
        public JsonResult FillCategory ( int[] ids )
        {
            if (ids.Count( ) != 0)
            {
                List<Category> categories = new List<Category>( );

                for (int i = 0; i < ids.Count( ); i++)
                {
                    categories.AddRange(_categoryService.GetCategoriesByMainCategoryId(ids[i]));
                }

                return Json(new
                {
                    status = 200,
                    data = categories
                });
            }
            else
            {
                return Json(new
                {
                    status = 400
                });
            }
        }
        [HttpPost]
        public JsonResult FillSubCategory ( int[] ids )
        {
            if (ids.Count( ) != 0)
            {
                List<SubCategory> subCategories = new List<SubCategory>( );

                for (int i = 0; i < ids.Count( ); i++)
                {
                    int id = ids[i];
                    List<SubCategory> subCategories2 = _subCategoryService.GetSubCategoriesByCategoryId(id);
                    subCategories.AddRange(subCategories2);
                }

                return Json(new
                {
                    status = 200,
                    data = subCategories
                });
            }
            else
            {
                return Json(new
                {
                    status = 400
                });
            }
        }
        [HttpPost]
        public JsonResult FillBrandModels ( int id )
        {
            if (id != 0)
            {
                List<Entity.Models.BrandModel> brandModels = _brandModelService.GetModelsByBrandId(id);
                return Json(new
                {
                    status = 200,
                    data = brandModels
                });
            }
            else
            {
                return Json(new
                {
                    status = 400
                });
            }
        }
        [HttpPost]
        public JsonResult FillOptionValues ( int[] ids )
        {
            if (ids.Count( ) != 0)
            {
                List<OptionValue> optionValues = new List<OptionValue>( );

                for (int i = 0; i < ids.Count( ); i++)
                {
                    int id = ids[i];
                    List<OptionValue> optionValues2 = _optionValueService.GetOptionValuesByOptionId(id);
                    optionValues.AddRange(optionValues2);
                }

                return Json(new
                {
                    status = 200,
                    data = optionValues
                });
            }
            else
            {
                return Json(new
                {
                    status = 400
                });
            }
        }
    }
}
