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
        IRepository<Card> getCardRepo();
        IRepository<Category> getCategoryRepo();
        IRepository<User> getUserRepo();
        IRepository<Images> getImagesRepo();
        IRepository<Likes> getLikesRepo();
        IRepository<Orders> getOrdersRepo();
        IRepository<OrderItems> getOrderItemsRepo();
        IRepository<Phone> getPhoneRepo();
        IRepository<Product> getProductRepo();
        IRepository<Reviews> getReviewsRepo();
        IRepository<Wishlist> getWishlistRepo();
        IRepository<Cart> getCartRepo();
        void Save();
    }
}
