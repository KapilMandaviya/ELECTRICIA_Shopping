import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { BlogServicesDetail, ServicesDetail } from '../../Dto/commonclass/commonclass';

@Component({
  selector: 'app-services-details',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './services-details.component.html',
  styleUrl: './services-details.component.css'
})
export class ServicesDetailsComponent {

  services: ServicesDetail[] = []; // Initialize as an empty array
  blogDetails:BlogServicesDetail[] = []; // Initialize as an empty array
  constructor(private Services:CommonApiService ,private routes:Router, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
    if (isPlatformBrowser(this.platformId)) {
    this.Services.getServicesList().subscribe({
      next: (success:any) => {
        this.services =success ;
        
      },
        
    });

    this.Services.getBlogServicesList().subscribe({
      next: (success:any) => {
        this.blogDetails =success ;
        
        
      },
        
    });
    
    
  };
    
    } 


}
