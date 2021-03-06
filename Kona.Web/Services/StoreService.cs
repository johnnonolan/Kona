﻿using System.Collections.Generic;
using System.Linq;
using Kona.Model;
using Kona.ViewModels;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;
using NHibernate.Transform;

namespace Kona.App.Services {
    public interface IStoreService{
        ProductListViewModel GetHomeModel(int categoryId);
        DetailsViewModel GetDetails(string sku);
    }

    public class StoreService : IStoreService{

        ISession _session;
        public StoreService(ISession session) {
            _session = session;
            
        }

        public ProductListViewModel GetHomeModel(int categoryId){

            var result = new ProductListViewModel();

            var categories = _session
                .CreateCriteria<Category>()
                .Future<Category>();

            result.Categories = categories;
            result.SelectedCategory = categories.SingleOrDefault(x => x.ID == categoryId);
            IEnumerable<Product> selectProducts = SelectProducts(categoryId);

            if (selectProducts.Count() > 0)
            {
                result.FeaturedProduct = selectProducts.First();
                result.FeaturedProducts = selectProducts
                    .Skip(1)
                    .Take(3)
                    .ToList();
            }
            else
            {
                result.FeaturedProduct = new Product();
                result.FeaturedProducts = new List<Product>();
            }

            return result;

        }

        public DetailsViewModel GetDetails(string sku)
        {
            var result = new DetailsViewModel();
            
            result.Categories = GetCategories();
            
            result.SelectedProduct = GetSelectedProduct(sku);

            result.Recommended = GetRecommendedProducts(sku);

            return result;
        }

        private IEnumerable<Product> SelectProducts(int categoryId)
        {
            return _session
                .CreateCriteria<Product>()
                .SetFetchMode<Product>(x=>x.Descriptors,FetchMode.Join)
                .CreateCriteria<Product>(x=>x.Categories)
                .Add(Expression.Or(Expression.Eq("ID", categoryId), Expression.Eq("Parent.ID", categoryId)))
                .SetResultTransformer(Transformers.DistinctRootEntity)
                .Future<Product>();
        }

        private IList<Product> GetRecommendedProducts(string sku)
        {
            var orderIDsContainingCurrentSku=DetachedCriteria.For<OrderItem>()
                .Add<OrderItem>(x=>x.Product.SKU==sku)
                .SetProjection(Projections.Property("Order.id"));

            var skusOfProductsAppearingInOrdersContainingCurrentSku = 
                DetachedCriteria.For<OrderItem>()
                    .SetProjection(Projections.GroupProperty("Product.id"))
                    .AddOrder(NHibernate.Criterion.Order.Desc(Projections.Count("Order.id")))
                    .Add<OrderItem>(x=>x.Product.SKU!=sku)
                    .Add(Subqueries.PropertyIn("Order.id", orderIDsContainingCurrentSku))
                    .SetMaxResults(15);

            return _session.CreateCriteria<Product>()
                .SetFetchMode<Product>(x => x.Descriptors, FetchMode.Join)
                .Add(Subqueries.PropertyIn("id", skusOfProductsAppearingInOrdersContainingCurrentSku))
                .SetResultTransformer(Transformers.DistinctRootEntity)
                .List<Product>();
        }

        private Product GetSelectedProduct(string sku)
        {
            return _session.Get<Product>(sku);
        }

        private IEnumerable<Category> GetCategories()
        {
            return _session
                .CreateCriteria<Category>()
                .Future<Category>();
        }
    }
}
