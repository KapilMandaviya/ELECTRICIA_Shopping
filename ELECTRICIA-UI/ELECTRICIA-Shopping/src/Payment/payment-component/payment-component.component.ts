import { Component, OnInit, AfterViewInit } from '@angular/core';
import { PaymentService } from '../../Services/PaymentServices/payment.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../Services/Login/login.service';

@Component({
  selector: 'app-payment-component',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './payment-component.component.html',
  styleUrls: ['./payment-component.component.css']  // fixed typo
})
export class PaymentComponentComponent implements OnInit, AfterViewInit {
  product: any[] = [];
  totalAmount = 0; // in ₹
  isLoading = false;
  returnUrl = 'http://localhost:4200/product-payment-success';
  userData = {
  firstName: '',
  lastName: '',
  email: '',
  phone: '',
  address: '',
  city: '',
  postalCode: ''
};


  constructor(
    private paymentService: PaymentService,
    public loginServices:LoginService,
    private toastr: ToastrService,
    private router: Router,
    private cartService: CartService
  ) {

     if (loginServices.IsLogin()) {
    this.loadUserData(); // simulate API call
  }
  }

  ngOnInit() {
    // Load cart items
    this.product = this.cartService.cartItems || [];
    this.totalAmount = this.product.reduce(
      (sum, item) => sum + item.price * (item.quantity || 1),
      0
    );
  }

  async ngAfterViewInit() {
    // Stripe element should be initialized after the DOM is ready
    if (!this.totalAmount) return;

    try {
      await this.paymentService.startPayment(
        this.totalAmount * 100, // convert ₹ to cents
        '#payment-element',
        this.returnUrl
      );
      console.log('Stripe initialized successfully');
    } catch (err) {
      console.error('Stripe initialization failed', err);
    }
  }

  async pay() {
    this.isLoading = true;
    const cardholderName = (document.getElementById('cardholder-name') as HTMLInputElement)?.value;

    if (!cardholderName) {
      this.toastr.error('Please enter cardholder name');
      this.isLoading = false;
      return;
    }

    const error = await this.paymentService.pay(cardholderName);
    this.isLoading = false;

    if (error) {
      this.toastr.error(error.message || 'Payment failed');
    }
  }
   goToLogin(): void {
    this.router.navigate(['account-auth']);
  }

  loadUserData() {
  // Replace with actual API call if needed
  this.userData = {
    firstName: 'John',
    lastName: 'Doe',
    email: 'john@example.com',
    phone: '9876543210',
    address: '123 Example St',
    city: 'Mumbai',
    postalCode: '400001'
  };
}
}
