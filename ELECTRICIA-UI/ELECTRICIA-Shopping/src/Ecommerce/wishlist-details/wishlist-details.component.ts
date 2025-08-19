import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';  // Import RouterModule
import { CommonEngine } from '@angular/ssr';
import { WishListService } from '../../Services/Wish-List/wish-list.service';
import { CartItem, wishlistItem } from '../../Dto/commonclass/commonclass';
import { ToastrService } from 'ngx-toastr';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { LoginService } from '../../Services/Login/login.service';

@Component({
  selector: 'app-wishlist-details',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './wishlist-details.component.html',
  styleUrl: './wishlist-details.component.css'
})
export class WishlistDetailsComponent implements OnInit {
wishlistItem: wishlistItem[] = [];

  constructor(private wishListServices: WishListService,private loginservices:LoginService,private cartServices: CartService,private toaster:ToastrService) {}

  ngOnInit(): void {
    this.loadwishlist();
  }

  loadwishlist() {
    //this.wishlistItem = this.wishListServices.getwishlist();
    const tokenPayload = this.loginservices.decodeTokens();

    if (tokenPayload?.UserId) {
      this.wishListServices.getWishListItemFromDB(tokenPayload.UserId).subscribe({
        next: (items) => {
          this.wishlistItem = items;
          localStorage.setItem('guestwishlist', JSON.stringify(items));
          
        },
        error: (err) => {
          console.error('Error fetching cart from DB:', err);
          this.wishlistItem = [];
        }
      });
    } else {
      this.wishlistItem = this.wishListServices.getwishlist();
      
    }
    
  }

  remove(productId: number) {
    
    this.wishListServices.removeFromwishlist(productId);
    this.loadwishlist();
  }
  clearwishlist() {
    this.wishListServices.clearwishlist();
    this.wishlistItem = [];
    this.toaster.success('wishlist clear successfully!', 'Success');
  }


   increaseQty(item: wishlistItem) {
    
    item.quantity += 1;
    this.wishListServices.savewishlist(this.wishlistItem); // update in localStorage
  }

  decreaseQty(item: wishlistItem) {
    // Ensure quantity does not go below 1
    if (item.quantity > 1) {
      item.quantity -= 1;
      this.wishListServices.savewishlist(this.wishlistItem);
    }
  }

  getTotal(): number {
    return this.wishlistItem.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }
  

  addToCart(product: any) {
     
    // Validate product details before adding to cart
    if (!product || !product.productId || !product.productName || !product.imageUrl || !product.price) {
      this.toaster.error('Invalid product details');
      return;     
    } 
  
  
    const cartItem: CartItem = {
      // categoryId: product.categoryId, // Assuming product has a categoryId property
      // categoryName: product.categoryName, // Assuming product has a categoryName property
      productId: product.productId,
      productName: product.productName,
      imageUrl: product.imageUrl,
      price: product.price,
      quantity: 1,
      totalPrice: product.price * 1 // Assuming quantity is 1 for now
      
    };
     var existingItem = this.cartServices.getCart().filter(item => item.productId == cartItem.productId);
      
      if (existingItem.length > 0) {
        // Item already in cart
        this.toaster.warning('Item already in cart!', 'Warning');
      } else {
        // Add new item to cart
        this.cartServices.addToCart(cartItem);
        this.toaster.success('Item added to cart!', 'Success');
      }
    this.remove(product.productId); // Remove from wishlist after adding to cart
    }
  
  
    
}
