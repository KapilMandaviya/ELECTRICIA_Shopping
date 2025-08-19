import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { LoginService } from '../../Services/Login/login.service';
import { CommonModule, isPlatformBrowser } from '@angular/common';

import { ContactUs } from '../../Dto/commonclass/commonclass';
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { JsonparsevaluePipe } from '../../Dto/jsonparsevalue.pipe';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule, JsonparsevaluePipe],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {



  categories: any[] = [];  // Array to hold the categories from the API

  contacts: ContactUs[] = []; // Initialize as an empty array
  constructor(public Services: CommonApiService, public LoginService: LoginService, private routes: Router, private toaster: ToastrService, @Inject(PLATFORM_ID) private platformId: Object) {

    this.Services.getCategoryListForHeader().subscribe((data) => {

      this.categories = data;
       
    });

  }

isDropdownOpen: boolean = false;

toggleDropdown() {
  this.isDropdownOpen = !this.isDropdownOpen;
}

closeDropdown() {
  this.isDropdownOpen = false;
}


} 