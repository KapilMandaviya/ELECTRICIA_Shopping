import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule } from '@angular/router';  // Import RouterModule
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-about-detail',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './about-detail.component.html',
  styleUrl: './about-detail.component.css'
})
export class AboutDetailComponent 
{

  AboutHeader:string="About Us";
  AboutContent:string="This is the about us page";
  constructor(private Services:CommonApiService ,private routes:Router, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
    if (isPlatformBrowser(this.platformId)) {
    this.Services.getAboutUs().subscribe({
      next: (success:any) => {
        this.AboutHeader=success.aboutHeader;
        this.AboutContent=success.aboutDescription;
      },
        
    });
  };
    
    } 
     

}
