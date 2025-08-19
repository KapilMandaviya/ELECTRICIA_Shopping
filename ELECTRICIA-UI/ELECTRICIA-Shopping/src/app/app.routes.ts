import { RouterModule, Routes } from '@angular/router';
import { AccountAuthComponent } from '../Authentication/account-auth/account-auth.component';

import  { HomeComponent} from '../front-end/home/home.component';
import  { CartDetailsComponent } from '../Ecommerce/cart-details/cart-details.component'
import  { WishlistDetailsComponent } from '../Ecommerce/wishlist-details/wishlist-details.component'
import  {AboutDetailComponent } from '../Pages/about-detail/about-detail.component'
import  { ContactDetailsComponent } from '../Pages/contact-details/contact-details.component'
import  {FAQDetailComponent } from '../Pages/faq-detail/faq-detail.component'
import  {ServicesDetailsComponent } from '../Pages/services-details/services-details.component'
import  { CategoriesDetailsComponent } from '../Ecommerce/categories-details/categories-details.component'
import  { CheckoutDetailsComponent } from '../Ecommerce/checkout-details/checkout-details.component'
import  { ShopDetailsComponent } from '../Pages/shop-details/shop-details.component'
import  { SingleproductDetailsComponent } from '../Ecommerce/singleproduct-details/singleproduct-details.component'
import  { BlogDetailComponent } from '../Pages/blog-detail/blog-detail.component'
import  { BlogsComponent } from '../Pages/blogs/blogs.component'
import { PaymentComponentComponent } from '../Payment/payment-component/payment-component.component';
import { PaymentSuccessComponent } from '../Payment/payment-success/payment-success.component';




export const routes: Routes = [
  { path: '', component: HomeComponent },// Default route
    { path: 'product-payment-success', component: PaymentSuccessComponent },
  { path: 'account-auth', component: AccountAuthComponent }, 
  { path: 'cart-details', component: CartDetailsComponent} ,
  //{ path: 'cart-details', component: CartDetailsComponent,canActivate:[authguarddetailGuard] } ,
  { path: 'wishlist-details', component: WishlistDetailsComponent},  
  { path: 'about-details', component:AboutDetailComponent,data: { skipSsr: true } }, 
  { path: 'contact-details', component:ContactDetailsComponent} ,
  { path: 'faq-details', component:FAQDetailComponent} ,
  { path: 'services-details', component:ServicesDetailsComponent} ,
  { path: 'categories-details', component:CategoriesDetailsComponent} ,
  {path: 'checkout-details', component:CheckoutDetailsComponent} ,
  { path: 'shop-details/:id/:name', component: ShopDetailsComponent },

  {path: 'singleproduct-detail/:id/:name', component:SingleproductDetailsComponent} ,
  {path: 'blogdetail-detail/:blog_Id', component:BlogDetailComponent} ,
  {path: 'blogs-detail', component:BlogsComponent} ,
  {path: 'payment-detail', component:PaymentComponentComponent} ,
  
  
  
  // Add more routes as needed

]; 



  // // @NgModule({
  // //   imports: [RouterModule.forRoot(routes)],  // Configure the router with the routes
  // //   exports: [RouterModule]
    
  // // })

  // export class AppModule { }


  
  