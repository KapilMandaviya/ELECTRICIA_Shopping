import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule } from '@angular/router';  // Import RouterModule
import { FAQDetail } from '../../Dto/commonclass/commonclass';
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule, isPlatformBrowser } from '@angular/common';
@Component({
  selector: 'app-faq-detail',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './faq-detail.component.html',
  styleUrl: './faq-detail.component.css'
})
export class FAQDetailComponent {

 faqdetails: FAQDetail[] = []; // Initialize as an empty array
    constructor(private Services:CommonApiService ,private routes:Router, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
      if (isPlatformBrowser(this.platformId)) {
      this.Services.getFAQList().subscribe({
        next: (success:any) => {
          this.faqdetails =success ;
        },
      });
    };
  } 

}
