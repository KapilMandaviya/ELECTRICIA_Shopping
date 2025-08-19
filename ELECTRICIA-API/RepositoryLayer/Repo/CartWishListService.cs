using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLayer.DTO;

namespace RepositoryLayer.Repo
{
    public class CartWishListService : ICartWishList
    {
        private readonly ELECTRICIADBContext _Context;
        public CartWishListService(ELECTRICIADBContext eLECTRICIADBContext)
        {
            this._Context = eLECTRICIADBContext;
        }

        public async Task<(int result, string errorMessage)> deleteCartandWishList(cart_WishlistRemoveDto cart_Dto)
        {
            try
            {
                var username =await _Context.UserMasters
                                .Where(x => x.UserId == cart_Dto.UserId && x.IsDelete == false)
                                .Select(x => new
                                {
                                    x.Email

                                })
                                .FirstOrDefaultAsync();
                if (username != null)
                {
                    if (cart_Dto.Cart_ProductId != null && cart_Dto.Cart_ProductId != 0)
                    {
                        var checkforcart = await _Context.Carts.Where(x => x.UserId == cart_Dto.UserId && x.ProductId == cart_Dto.Cart_ProductId).FirstOrDefaultAsync();
                        if (checkforcart != null)
                        {
                            _Context.Carts.Remove(checkforcart);
                            await _Context.SaveChangesAsync();
                            return (1, "Cart Item Delete Successfully!");
                        }
                        
                    }
                    else if (cart_Dto.wishlist_ProductId != null && cart_Dto.wishlist_ProductId != 0)
                    {

                        var checkforwishlist = await _Context.WishlistsMasters.Where(x => x.UserId == cart_Dto.UserId && x.ProductId == cart_Dto.wishlist_ProductId).FirstOrDefaultAsync();
                        if (checkforwishlist != null)
                        {
                            _Context.WishlistsMasters.Remove(checkforwishlist);
                            await _Context.SaveChangesAsync();
                            return (1, "wishlist Item Delete Successfully!");
                        }
                    }
                     
                    return (0, "Item not found");
                     
                }
                else
                {
                    return (0, "User not found.");
                }
            }
            catch (Exception ex)
            {
                return (0, "Something went wrong.");
            }
            
        }

        public async Task<(int result, string errorMessage)> ClearAndSaveCartAndWishList(Cart_dto cart_Dto)
        {
            try
            {
                int isflag = 0;

                var user = await _Context.UserMasters
                    .Where(x => x.UserId == cart_Dto.UserId && x.IsDelete == false)
                    .Select(x => new { x.Email })
                    .FirstOrDefaultAsync();

                if (user == null)
                    return (0, "User not found.");

                // STEP 1: Clear existing cart and wishlist
                var existingCarts = _Context.Carts.Where(x => x.UserId == cart_Dto.UserId);
                _Context.Carts.RemoveRange(existingCarts);

                var existingWishlists = _Context.WishlistsMasters.Where(x => x.UserId == cart_Dto.UserId);
                _Context.WishlistsMasters.RemoveRange(existingWishlists);

                await _Context.SaveChangesAsync(); // Save deletion

                // STEP 2: Add new Cart items
                foreach (var cartDto in cart_Dto.CartItem)
                {
                    var cart = new Cart
                    {
                        UserId = cart_Dto.UserId,
                        ProductId = cartDto.ProductId,
                        ProductName = cartDto.productName,
                        ImageUrl = cartDto.imageUrl,
                        Price = cartDto.price,
                        Subtotal = cartDto.totalPrice,
                        Quantity = cartDto.quantity,
                        CreatedDate = DateTime.Now,
                        CreatedByUserId = user.Email,
                        IsDelete = false
                    };

                    _Context.Carts.Add(cart);
                    isflag = 1;
                }

                // STEP 3: Add new Wishlist items
                foreach (var itemDto in cart_Dto.Wishlistitem)
                {
                    var wishlist = new WishlistsMaster
                    {
                        UserId = cart_Dto.UserId,
                        ProductId = itemDto.ProductId,
                        ProductName = itemDto.productName,
                        ImageUrl = itemDto.imageUrl,
                        Price = itemDto.price,
                        Subtotal = itemDto.totalPrice,
                        Quantity = itemDto.quantity,
                        CreatedDate = DateTime.Now,
                        CreatedByUserId = user.Email,
                        IsDelete = false
                    };

                    _Context.WishlistsMasters.Add(wishlist);
                    isflag = 1;
                }

                await _Context.SaveChangesAsync(); // Final save after insert

                return (1, "Cart & Wishlist synced with latest local state.");
            }
            catch (Exception ex)
            {
                // Optionally log ex.Message
                return (0, "Something went wrong while syncing.");
            }
        }

        public async Task<List<CartItem_DTO>> getUserWiseCartList(int? Id)
        {
            try
            {
                var cartitemlist = await _Context.Carts.Where(x => x.UserId == Id).Select(x => new CartItem_DTO
                {
                    ProductId = x.ProductId,
                    productName = x.ProductName,       // Assuming navigation property
                    imageUrl = x.ImageUrl,       // Assuming navigation property
                    price = x.Price,
                    quantity = x.Quantity,
                    totalPrice = x.Subtotal
                }).ToListAsync();
                
                return cartitemlist;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<WishlistItem_DTO>> getUserWiseWishList(int? Id)
        {
            try
            {
                var cartitemlist = await _Context.WishlistsMasters.Where(x => x.UserId == Id).Select(x => new WishlistItem_DTO
                {
                    ProductId = x.ProductId,
                    productName = x.ProductName,       // Assuming navigation property
                    imageUrl = x.ImageUrl,       // Assuming navigation property
                    price = x.Price,
                    quantity = x.Quantity,
                    totalPrice = x.Subtotal
                }).ToListAsync();

                return cartitemlist;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
