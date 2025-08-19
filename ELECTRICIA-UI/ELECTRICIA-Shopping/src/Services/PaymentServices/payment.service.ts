import { Inject, Injectable, PLATFORM_ID } from '@angular/core';

import { loadStripe, Stripe, StripeElements, StripePaymentElement } from '@stripe/stripe-js';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

    private stripePromise = loadStripe(environment.stripePublicKey);
  private stripe: Stripe | null = null;
  private elements: StripeElements | null = null;
  private paymentElement: StripePaymentElement | null = null;
  private clientSecret: string = '';
    private returnUrl: string = '';
  

   constructor( private route:Router,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object,
    ) { 
        }

        
async getStripe(): Promise<Stripe> {
  if (!this.stripe) {
    this.stripe = await this.stripePromise;
    if (!this.stripe) {
      throw new Error('Stripe failed to initialize');
    }
  }
  return this.stripe;
}

   // Call backend to create PaymentIntent
  createPaymentIntent(amount: number): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/Payment/create-payment-intent`, { amount });
  }

    
  // Start payment by creating intent and mounting element
  async startPayment(amount: number, elementId: string, returnUrl: string) {
    await this.getStripe();

    return new Promise<void>((resolve, reject) => {
      this.createPaymentIntent(amount).subscribe({
        next: async (res) => {
          this.clientSecret = res.clientSecret;
          this.returnUrl = returnUrl;

          this.elements = this.stripe!.elements({ clientSecret: this.clientSecret });
          this.paymentElement = this.elements.create('payment', { layout: 'tabs' });
          this.paymentElement.mount(elementId);

          resolve();
        },
        error: reject
      });
    });
  }

  // Confirm payment with cardholder name
  async pay(cardholderName: string) {
    if (!this.stripe || !this.elements) {
      alert('Stripe not initialized');
      throw new Error('Stripe not initialized');
    }

    const { error } = await this.stripe.confirmPayment({
      elements: this.elements,
      confirmParams: {
        return_url: this.returnUrl,
        payment_method_data: {
          billing_details: { name: cardholderName }
        }
      }
    });

    return error;
  } 


}
