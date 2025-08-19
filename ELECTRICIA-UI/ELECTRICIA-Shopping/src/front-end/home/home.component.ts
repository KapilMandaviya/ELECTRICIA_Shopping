import { Component, Inject,   OnDestroy,   OnInit,   PLATFORM_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DashboardService } from '../../Services/Dashboard/dashboard.service';
import { interval, Subscription } from 'rxjs';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
  
})
//https://localhost:7278/api/Home/getTopDiscountProduct
export class HomeComponent implements OnInit, OnDestroy {
  categories: any[] = [];  // Array to hold the categories from the API 
  feautredProducts: any[] = [];  // Array to hold the categories from the API 
  topArrivalProducts: any[] = [];  // Array to hold the categories from the API 
  countdowns: { [key: number]: any } = {};  // store countdown per product
  feautredCountdowns: { [key: number]: any } = {};  // store countdown per product
  topArrivalCountdowns: { [key: number]: any } = {};  // store countdown per product
  timerSubscription!: Subscription;
  constructor(private Services:DashboardService,private routes: Router, private toaster: ToastrService, @Inject(PLATFORM_ID) private platformId: Object) {
 
     
  }
 
     ngOnInit() {
    this.Services.getTopDiscountProduct().subscribe((data) => {
      this.categories = data;

      // Start timer only after categories are loaded
      this.updateCountdowns();
      this.timerSubscription = interval(1000).subscribe(() => this.updateCountdowns());
    });

    this.Services.GET_TopFeauteredProduct().subscribe((data) => {
      this.feautredProducts = data;

       this.feautredupdateCountdown();
      this.timerSubscription = interval(1000).subscribe(() => this.feautredupdateCountdown());
    });

      this.Services.GET_TopNewArrivalProducts().subscribe((data) => {
      this.topArrivalProducts = data;
       this.topArrivalProducts.forEach(item => {
        console.log(item);
       });
       this.topupdateCountdown();
      this.timerSubscription = interval(1000).subscribe(() => this.topupdateCountdown());
    });
  }

  updateCountdowns() {
    if (!this.categories || this.categories.length === 0) return;

    const now = new Date().getTime();

    this.categories.forEach(item => {
      const endTime = new Date(item.endDate).getTime();
      let timeLeft = endTime - now;

      if (timeLeft < 0) {
        timeLeft = 0;
      }

      this.countdowns[item.productId] = {
        days: Math.floor(timeLeft / (1000 * 60 * 60 * 24)),
        hours: Math.floor((timeLeft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)),
        minutes: Math.floor((timeLeft % (1000 * 60 * 60)) / (1000 * 60)),
        seconds: Math.floor((timeLeft % (1000 * 60)) / 1000),
      };
    });
  }

  feautredupdateCountdown() {
    if (!this.feautredProducts || this.feautredProducts.length === 0) return;

    const now = new Date().getTime();

    this.feautredProducts.forEach(item => {
      const endTime = new Date(item.discountEndDate).getTime();
      let timeLeft = endTime - now;

      if (timeLeft < 0) {
        timeLeft = 0;
      }

      this.feautredCountdowns[item.productId] = {
        days: Math.floor(timeLeft / (1000 * 60 * 60 * 24)),
        hours: Math.floor((timeLeft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)),
        minutes: Math.floor((timeLeft % (1000 * 60 * 60)) / (1000 * 60)),
        seconds: Math.floor((timeLeft % (1000 * 60)) / 1000),
      };
    });
  }

  topupdateCountdown() {
    if (!this.topArrivalProducts || this.topArrivalProducts.length === 0) return;

    const now = new Date().getTime();

    this.topArrivalProducts.forEach(item => {
      
      const endTime = new Date(item.discountEndDate).getTime();
      let timeLeft = endTime - now;

      if (timeLeft < 0) {
        timeLeft = 0;
      }
      
      this.topArrivalCountdowns[item.productId] = {
        days: Math.floor(timeLeft / (1000 * 60 * 60 * 24)),
        hours: Math.floor((timeLeft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)),
        minutes: Math.floor((timeLeft % (1000 * 60 * 60)) / (1000 * 60)),
        seconds: Math.floor((timeLeft % (1000 * 60)) / 1000),
      };
    });
  }

  ngOnDestroy() {
    if (this.timerSubscription) {
      this.timerSubscription.unsubscribe();
    }
  }
 
 
}
