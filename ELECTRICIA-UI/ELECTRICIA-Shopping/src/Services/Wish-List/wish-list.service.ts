import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { wishlistItem } from '../../Dto/commonclass/commonclass';
import { LoginService } from '../Login/login.service';
import { CartService } from '../Cart-Services/cart.service';
import { map, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class WishListService {

  constructor(private loginServices:LoginService,private cartServices:CartService,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object ) { }

    private storageKey = 'guestwishlist';
  
    getwishlist(): wishlistItem[] {
      return JSON.parse(localStorage.getItem(this.storageKey) || '[]');
    }
  
    savewishlist(wishlist: wishlistItem[]): void {
      localStorage.setItem(this.storageKey, JSON.stringify(wishlist));
      const token = this.loginServices.decodeTokens();

    if (token && token.UserId != null && token.UserId != undefined) {
      // Sync cart with backend
       this.syncCartAndWishlist(token.UserId, wishlist);
    }  
     }
  
    addTowishlist(product: wishlistItem): void {
      
      const wishlist = this.getwishlist();
      const index = wishlist.findIndex(item => item.productId === product.productId);
  
      if (index !== -1) {
        wishlist[index].quantity += product.quantity;
      } else {
        wishlist.push(product);
      }
  
      this.savewishlist(wishlist);
    }
  
    removeFromwishlist(productId: number): void {
      const wishlist = this.getwishlist().filter(item => item.productId !== productId);
      this.savewishlist(wishlist);
      const tokenPayload=this.loginServices.decodeTokens();
      if(tokenPayload && tokenPayload.UserId)
      { 
        this.cartServices.removeItemCartAndWishlist(tokenPayload.UserId,0,productId); // Assuming 0 for wishlist_ProductId
      }
    }
  
    clearwishlist(): void {
      localStorage.removeItem(this.storageKey);
    }
    
     public getWishListItemFromDB(Id:number): Observable<wishlistItem[]> {
      
        return this.http.get<wishlistItem[]>(`${environment.apiUrl}/CartWishList/getUserWiseWishList/${Id}`)
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
    // getTotalAmount(): number {
    //   return this.getwishlist().reduce((total, item) => total + item.price * item.quantity, 0);
    // }

    //checkLoginDetail(){}
   syncCartAndWishlist(userId: number, wishlistItem: wishlistItem[]): void {
       // Assuming wishlist stored in localStorage similarly
       const localcart = JSON.parse(localStorage.getItem('guestCart') || '[]');
   
       const payload = {
         userId: userId,
         cartItems: localcart,
         wishlistItems: wishlistItem
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
}

