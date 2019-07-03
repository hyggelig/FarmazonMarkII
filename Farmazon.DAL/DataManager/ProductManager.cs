using Farmazon.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmazon.DAL.DataManager
{
    public class ProductManager : IDataRepository<Products>
    {
        readonly FarmaContext _productsContext;

        public ProductManager(FarmaContext context)
        {
            _productsContext = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return _productsContext.Product.ToList();
        }



        public Products Get(long id)
        {
            return _productsContext.Product
                  .FirstOrDefault(e => e.productId == id);
        }

        public void Create(Products entity)
        {
            _productsContext.Product.Add(entity);
            _productsContext.SaveChanges();
        }

        public void Update(Products product, Products entity)
        {
            product.productId = entity.productId;
            product.productName = entity.productName;
            product.productOwnerId = entity.productOwnerId;
            product.productOwnerName = entity.productOwnerName;
            product.productOwnerLastName = entity.productOwnerLastName;

            _productsContext.SaveChanges();
        }

        public void Delete(Products product)
        {
            _productsContext.Product.Remove(product);
            _productsContext.SaveChanges();
        }

        public IEnumerable<Products> GetUsersProducts(long ownerId, string ownerName, string ownerLastName)
        {
            return _productsContext.Product.Where(x => x.productOwnerId == ownerId && x.productOwnerName == ownerName && x.productOwnerLastName == ownerLastName).ToList();
        }
    }
}


