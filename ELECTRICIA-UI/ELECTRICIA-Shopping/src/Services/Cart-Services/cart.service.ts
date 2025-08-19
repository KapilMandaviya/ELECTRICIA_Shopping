import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { CartItem, wishlistItem } from '../../Dto/commonclass/commonclass'; // Adjust
import { LoginService } from '../Login/login.service';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { WishListService } from '../Wish-List/wish-list.service';
import {  map,Observable, of  } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  

  constructor(private loginServices:LoginService,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object ) { }
 cartItems: any[] = [];
    private storageKey = 'guestCart';
    private wishliststorageKey = 'guestwishlist';
  

  getCart(): CartItem[] {
    return JSON.parse(localStorage.getItem(this.storageKey) || '[]');
  }

   saveCart(cart: CartItem[]):void {
    localStorage.setItem(this.storageKey, JSON.stringify(cart));

    const token = this.loginServices.decodeTokens();

    if (token && token.UserId != null && token.UserId != undefined) {
      // Sync cart with backend
       this.syncCartAndWishlist(token.UserId, cart);
    }  
  }


  addToCart(product: CartItem):void {
    const cart = this.getCart();
    const index = cart.findIndex(item => item.productId === product.productId);

    if (index !== -1) {
      cart[index].quantity += product.quantity;
      cart[index].totalPrice = cart[index].price * cart[index].quantity;
    } else {
      cart.push(product);
    }

     this.saveCart(cart);
  }

  removeFromCart(productId: number):  Observable<any> {
    const cart = this.getCart().filter(item => item.productId !== productId);
    this.saveCart(cart);
    const tokenPayload=this.loginServices.decodeTokens();
    if(tokenPayload && tokenPayload.UserId)
    { 
      return this.removeItemCartAndWishlist(tokenPayload.UserId,productId,0); // Assuming 0 for wishlist_ProductId
    }else {
    return of(true); // ✅
    }
  }

  clearCart(): void {
    localStorage.removeItem(this.storageKey);
  }

  getTotalAmount(): number {
    return this.getCart().reduce((total, item) => total + item.price * item.quantity, 0);
  }

// saveCartandWishList(payload: any){
//   console.log("Function called with payload:", payload);
//   alert("saveCartandWishList");
//   //return this.http.post<any>(`${environment.apiUrl}/CartWishList/saveCartandWishList`, payload);
//   return this.http.post<any>(`${environment.apiUrl}/CartWishList/saveCartandWishList`, payload);
// }


  deleteCartandWishList(payload: any): Observable<any> {
    
    // Assuming payload contains userId, Cart_ProductId, and wishlist_ProductId
    // Adjust the endpoint URL as needed
    return this.http.post<any>(`${environment.apiUrl}/CartWishList/deleteCartandWishList`, payload);
  }
 
 public getCartItemFromDB(Id:number): Observable<CartItem[]> {
  
    return this.http.get<CartItem[]>(`${environment.apiUrl}/CartWishList/getUserWiseCartList/${Id}`)
      .pipe(
        map(products => products.map(product => ({
          productId: product.productId,
          productName: product.productName,
          imageUrl: product.imageUrl,
          price: product.price,
          quantity: product.quantity,
          totalPrice: product.totalPrice
        })))
      );
    }
  //checkLoginDetail(){}
  syncCartAndWishlist(userId: number, cartItems: CartItem[]): void {
    // Assuming wishlist stored in localStorage similarly
    const localWishlist = JSON.parse(localStorage.getItem('guestwishlist') || '[]');

    const payload = {
      userId: userId,
      cartItems: cartItems,
      wishlistItems: localWishlist
    };
    
    
    this.http.post<any>(
    `${environment.apiUrl}/CartWishList/saveCartandWishList`,
    payload
  ).subscribe({
    next: (res) => {
    
    },
    error: (err) => {
      console.error('Error syncing cart', err);
    }
  });
  }

//checkLoginDetail(){}
  removeItemCartAndWishlist(userId: number,Cart_ProductId: number,wishlist_ProductId: number) :Observable<any> {
    const payload = {
      userId: userId,
      Cart_ProductId: Cart_ProductId,
      wishlist_ProductId: wishlist_ProductId     
    }
     return this.deleteCartandWishList(payload);

}

}
