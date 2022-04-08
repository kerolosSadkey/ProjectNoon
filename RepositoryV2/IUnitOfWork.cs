using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUnitOfWork
    {
        IRepository<Address> getAddressRepo();
        IRepository<Admin> getAdminRepo();
        IRepository<Card> getCardRepo();
        IRepository<Category> getCategoryRepo();
        IRepository<Customer> getCustomerRepo();
        IRepository<Images> getImagesRepo();
        IRepository<Likes> getLikesRepo();
        IRepository<Order> getOrderRepo();
        IRepository<OrderSummary> getOrderSummaryRepo();
        IRepository<Phone> getPhoneRepo();
        IRepository<Product> getProductRepo();
        IRepository<Reviews> getReviewsRepo();
        IRepository<Seller> getSellerRepo();
        IRepository<Shipper> getShipperRepo();
        IRepository<Wishlist> getWishlistRepo();
        IRepository<Cart> getCartRepo();
        void Save();
    }
}
