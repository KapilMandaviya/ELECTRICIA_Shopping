import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { loadStripe } from '@stripe/stripe-js';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../environments/environment';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-payment-success',
  standalone: true,
  imports: [CommonModule],
  // template: `<p id="test">Checking payment...</p>`,
  templateUrl: './payment-success.component.html',
  styleUrl: './payment-success.component.css'
})
export class PaymentSuccessComponent  implements OnInit {
    paymentIntentData: any = null;
  async ngOnInit() {
    const clientSecret = this.route.snapshot.queryParamMap.get('payment_intent_client_secret');
    if (!clientSecret) {
      this.toastr.error('Payment information not found.');
      this.router.navigate(['/']);
      return;
    }

    const stripe = await loadStripe(environment.stripePublicKey); // <-- your publishable key
    const { paymentIntent } = await stripe!.retrievePaymentIntent(clientSecret);
     if (paymentIntent) {
      this.paymentIntentData = paymentIntent;
    }


    if (paymentIntent?.status === 'succeeded') {
      alert('Payment successful!');
      this.toastr.success('Payment successful!');
       this.router.navigate(['product-payment-success']);
      
    } else {
      this.toastr.error('Payment failed or incomplete.');
      this.router.navigate(['/']);
    }
  }
  constructor( private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService) {
    
    
  }

}
