import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CartItem } from '../../Dto/commonclass/commonclass';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../../Services/Login/login.service';
import { finalize } from 'rxjs';
import { PaymentComponentComponent } from '../../Payment/payment-component/payment-component.component';
import { PaymentService } from '../../Services/PaymentServices/payment.service';



@Component({
  selector: 'app-cart-details',
  standalone: true,
  imports: [RouterModule, CommonModule,PaymentComponentComponent],
  templateUrl: './cart-details.component.html',
  styleUrl: './cart-details.component.css'
})
export class CartDetailsComponent implements OnInit {
  cartItems: CartItem[] = [];
totalAmount: number = 0; // Default value, will be updated based on cart items
  constructor(
    private paymentService: PaymentService,
    private cartService: CartService,
    private loginservices: LoginService,
    private toaster: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    
    this.loadCart();
  }

  loadCart(): void {
    const tokenPayload = this.loginservices.decodeTokens();

    if (tokenPayload?.UserId) {
      this.cartService.getCartItemFromDB(tokenPayload.UserId).subscribe({
        next: (items) => {
          this.cartItems = items;
          localStorage.setItem('guestCart', JSON.stringify(items));
          
        },
        error: (err) => {
          console.error('Error fetching cart from DB:', err);
          this.cartItems = [];
        }
      });
    } else {
      this.cartItems = this.cartService.getCart();
      
    }
  }

  remove(productId: number): void {
    this.cartService.removeFromCart(productId).pipe(
      finalize(() => this.loadCart()) // Reload cart after delete completes (success or fail)
    ).subscribe({
      next: () => {
        this.toaster.success('Item removed successfully!', 'Success');
      },
      error: (err) => {
        console.error('Error removing item:', err);
        this.toaster.error('Failed to remove item!', 'Error');
      }
    });
  }

  clearCart(): void {
    this.cartService.clearCart();
    this.cartItems = [];
    this.toaster.success('Cart cleared successfully!', 'Success');
  }

  increaseQty(item: CartItem): void {
    item.quantity += 1;
    item.totalPrice = item.price * item.quantity;
    this.cartService.saveCart(this.cartItems);
  }

  decreaseQty(item: CartItem): void {
    if (item.quantity > 1) {
      item.quantity -= 1;
      item.totalPrice = item.price * item.quantity;
      this.cartService.saveCart(this.cartItems);
    }
  }

  getTotal(): number {
     this.totalAmount=this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }

  updateCart(): void {
    this.cartService.saveCart(this.cartItems);
    this.loadCart();
    this.toaster.success('Cart updated successfully!', 'Success');
  }

checkout() {
  // Save cart items to service
  this.cartService.cartItems = this.cartItems;

  // Navigate to payment page
  this.router.navigate(['payment-detail']);
}
}
