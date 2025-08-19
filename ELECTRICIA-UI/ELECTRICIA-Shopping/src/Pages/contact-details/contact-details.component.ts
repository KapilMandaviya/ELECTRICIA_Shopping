import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule } from '@angular/router';  // Import RouterModule
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { ContactUs } from '../../Dto/commonclass/commonclass';
@Component({
  selector: 'app-contact-details',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './contact-details.component.html',
  styleUrl: './contact-details.component.css'
})
export class ContactDetailsComponent {
  contacts: ContactUs[] = []; // Initialize as an empty array
    constructor(private Services:CommonApiService ,private routes:Router, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
      if (isPlatformBrowser(this.platformId)) {
      this.Services.getContactUs().subscribe({
        next: (success:any) => {
        
          this.contacts =success ;
          
        },
          
      });
      
    };
      
      } 
}
