import { Component, inject   } from '@angular/core';
import { Route, Router, RouterModule } from '@angular/router';  // Import RouterModule
import { CommonModule } from '@angular/common';  // Import CommonModule
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';  // Import CommonModule

import { LoginService } from '../../Services/Login/login.service';
 


import { ToastrService } from 'ngx-toastr';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { WishListService } from '../../Services/Wish-List/wish-list.service';
import { CartItem } from '../../Dto/commonclass/commonclass';


@Component({
  selector: 'app-account-auth',
  standalone: true,
  imports: [CommonModule,RouterModule,ReactiveFormsModule],
  templateUrl: './account-auth.component.html',
  styleUrl: './account-auth.component.css'
  
  
})
export class AccountAuthComponent {
 cartItems: CartItem[] = [];
  type: string = 'password';
  isText: boolean = false;
  eyeIcon: string = 'fa-eye-slash';
  
  hideShowPass() {
     this.isText = !this.isText;
    this.isText ? (this.eyeIcon = 'fa-eye') : (this.eyeIcon = 'fa-eye-slash');
    this.isText ? (this.type = 'text') : (this.type = 'password');
  }

  /**
   *
   */
  constructor(private loginServices:LoginService ,private routes:Router, private toaster:ToastrService, private cartService:CartService,private wishlistService:WishListService) {
    // Check if the user is already logged in
  //console.log(this.loginServices.getRoleFromStorage());
  
  }

  loginGroup:FormGroup=new FormGroup({
      email:new FormControl(),
      password:new FormControl(),
      rememberME:new FormControl()
  });
  formvalue:any;

  checkLoginDetail(){
    this.formvalue=this.loginGroup.value;
 
     
        
        this.loginServices.loginEmployee(this.formvalue).subscribe({
          next: (success:any) => {
            if(success.message=="Login SuccessFully"){
              this.toaster.success(success.message, 'Success');
              this.loginServices.setToken(success.token);
              this.loginServices.storeRefreshToken(success.refreshToken)
              const tokenPayload=this.loginServices.decodeTokens();
              
              this.loginServices.setNameFromStore(tokenPayload.firstname+tokenPayload.lastname);
  
              this.loginServices.setRoleFromStore(tokenPayload.role);
              this.routes.navigate(['']);
              
            this.cartService.syncCartAndWishlist(tokenPayload.UserId, this.cartService.getCart());
            
            }
            else{
              this.toaster.error(success.message, 'Error');
            }
            
          },
           
        });
      
     
  }
  

}

