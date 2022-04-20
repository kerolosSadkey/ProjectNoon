using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext Context;
        IRepository<Address> AddressRepository;
        IRepository<Card> CardRepository;
        IRepository<Category> CategoryRepository;
        IRepository<User> UserRepository;
        IRepository<Images> ImagesRepository;
        IRepository<Likes> LikesRepository;
        IRepository<Orders> OrdersRepository;
        IRepository<OrderItems> OrderItemsRepository;
        IRepository<Phone> PhoneRepository;
        IRepository<Product> ProductRepository;
        IRepository<Reviews> ReviewsRepository;
        IRepository<Wishlist> WhishlistRepository;
        IRepository<Cart> CartRepository;

        // Constructor
        public UnitOfWork(IContextFactory ContextFactory,
        IRepository<Address> _AddressRepository,
        IRepository<Card> _CardRepository,
        IRepository<Category> _CategoryRepository,
        IRepository<User> _UserRepository,
        IRepository<Images> _ImagesRepository,
        IRepository<Likes> _LikesRepository,
        IRepository<Orders> _OrdersRepository,
        IRepository<OrderItems> _OrderItemsRepository,
        IRepository<Phone> _PhoneRepository,
        IRepository<Product> _ProductRepository,
        IRepository<Reviews> _ReviewsRepository,

        IRepository<Wishlist> _WhishlistRepository,
        IRepository<Cart> _CartRepository)
        {
            Context = ContextFactory.GetContext();
            AddressRepository = _AddressRepository;

            CardRepository = _CardRepository;
            CategoryRepository = _CategoryRepository;
            UserRepository = _UserRepository;
            ImagesRepository = _ImagesRepository;
            LikesRepository = _LikesRepository;
            OrdersRepository = _OrdersRepository;
            OrderItemsRepository = _OrderItemsRepository;
            PhoneRepository = _PhoneRepository;
            ProductRepository = _ProductRepository;
            ReviewsRepository = _ReviewsRepository;
            WhishlistRepository = _WhishlistRepository;
            CartRepository = _CartRepository;
        }

        public IRepository<Address> getAddressRepo()
        {
            return AddressRepository;
        }

        public IRepository<Card> getCardRepo()
        {
            return CardRepository;
        }

        public IRepository<Cart> getCartRepo()
        {
            return CartRepository;
        }

        public IRepository<Category> getCategoryRepo()
        {
            return CategoryRepository;
        }

        public IRepository<User> getUserRepo()
        {
            return UserRepository;
        }

        public IRepository<Images> getImagesRepo()
        {
            return ImagesRepository;
        }

        public IRepository<Likes> getLikesRepo()
        {
            return LikesRepository;
        }

        public IRepository<Orders> getOrdersRepo()
        {
            return OrdersRepository;
        }

        public IRepository<OrderItems> getOrderItemsRepo()
        {
            return OrderItemsRepository;
        }

        public IRepository<Phone> getPhoneRepo()
        {
            return PhoneRepository;
        }

        public IRepository<Product> getProductRepo()
        {
            return ProductRepository;
        }

        public IRepository<Reviews> getReviewsRepo()
        {
            return ReviewsRepository;
        }


        public IRepository<Wishlist> getWishlistRepo()
        {
            return WhishlistRepository;
        }

        // Save changes in database
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
