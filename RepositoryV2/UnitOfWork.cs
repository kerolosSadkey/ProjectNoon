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
        IRepository<Admin> AdminRepository;
        IRepository<Card> CardRepository;
        IRepository<Category> CategoryRepository;
        IRepository<Customer> CustomerRepository;
        IRepository<Images> ImagesRepository;
        IRepository<Likes> LikesRepository;
        IRepository<Order> OrderRepository;
        IRepository<OrderSummary> OrderSummaryRepository;
        IRepository<Phone> PhoneRepository;
        IRepository<Product> ProductRepository;
        IRepository<Reviews> ReviewsRepository;
        IRepository<Seller> SellerRepository;
        IRepository<Shipper> ShipperRepository;
        IRepository<Wishlist> WhishlistRepository;
        IRepository<Cart> CartRepository;

        // Constructor
        public UnitOfWork(IContextFactory ContextFactory,
        IRepository<Address> _AddressRepository,
        IRepository<Admin> _AdminRepository,
        IRepository<Card> _CardRepository,
        IRepository<Category> _CategoryRepository,
        IRepository<Customer> _CustomerRepository,
        IRepository<Images> _ImagesRepository,
        IRepository<Likes> _LikesRepository,
        IRepository<Order> _OrderRepository,
        IRepository<OrderSummary> _OrderSummaryRepository,
        IRepository<Phone> _PhoneRepository,
        IRepository<Product> _ProductRepository,
        IRepository<Reviews> _ReviewsRepository,
        IRepository<Seller> _SellerRepository,
        IRepository<Shipper> _ShipperRepository,
        IRepository<Wishlist> _WhishlistRepository,
        IRepository<Cart> _CartRepository)
        {
            Context = ContextFactory.GetContext();
            AddressRepository = _AddressRepository;
            AdminRepository = _AdminRepository;
            CardRepository = _CardRepository;
            CategoryRepository = _CategoryRepository;
            CustomerRepository = _CustomerRepository;
            ImagesRepository = _ImagesRepository;
            LikesRepository = _LikesRepository;
            OrderRepository = _OrderRepository;
            OrderSummaryRepository = _OrderSummaryRepository;
            PhoneRepository = _PhoneRepository;
            ProductRepository = _ProductRepository;
            ReviewsRepository = _ReviewsRepository;
            SellerRepository = _SellerRepository;
            ShipperRepository = _ShipperRepository;
            WhishlistRepository = _WhishlistRepository;
            CartRepository = _CartRepository;
        }

        public IRepository<Address> getAddressRepo()
        {
            return AddressRepository;
        }

        public IRepository<Admin> getAdminRepo()
        {
            return AdminRepository;
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

        public IRepository<Customer> getCustomerRepo()
        {
            return CustomerRepository;
        }

        public IRepository<Images> getImagesRepo()
        {
            return ImagesRepository;
        }

        public IRepository<Likes> getLikesRepo()
        {
            return LikesRepository;
        }

        public IRepository<Order> getOrderRepo()
        {
            return OrderRepository;
        }

        public IRepository<OrderSummary> getOrderSummaryRepo()
        {
            return OrderSummaryRepository;
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

        public IRepository<Seller> getSellerRepo()
        {
            return SellerRepository;
        }

        public IRepository<Shipper> getShipperRepo()
        {
            return ShipperRepository;
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
