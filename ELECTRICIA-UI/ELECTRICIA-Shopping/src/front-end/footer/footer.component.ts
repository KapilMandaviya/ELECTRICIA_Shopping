import { CommonModule } from '@angular/common';
import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { RouterModule } from '@angular/router';  // Import RouterModule
import { ProductServicesService } from '../../Services/ProductServices/product-services.service';
import { CartItem } from '../../Dto/commonclass/commonclass';
import { CartService } from '../../Services/Cart-Services/cart.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {
selectedProduct: any = null;

  constructor(private Services:ProductServicesService, private cartServices:CartService,private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
      
      
  }   
      

    ngOnInit() {
      this.Services.quickViewProduct$.subscribe(product => {
        this.selectedProduct = product;
        console.log('Selected Product:', this.selectedProduct);
      });
    }

    addToCart(product: any) {
        if (!product || !product.productId || !product.pName || !product.img_Name || !product.pBasePrice) {
          this.toaster.error('Invalid product details');
          return;     
        } 
      
      
        const cartItem: CartItem = {
          // categoryId: product.categoryId, // Assuming product has a categoryId property
          // categoryName: product.categoryName, // Assuming product has a categoryName property
          productId: product.productId,
          productName: product.pName,
          imageUrl: product.img_Name,
          price: product.pBasePrice,
          quantity: 1,
          totalPrice: product.pBasePrice * 1 // Assuming quantity is 1 for now
          
        };
         var existingItem = this.cartServices.getCart().filter(item => item.productId == cartItem.productId);
          
          if (existingItem.length > 0) {
            // Item already in cart
            this.toaster.warning('Item already in cart!', 'Warning');
          } else {
            // Add new item to cart
            this.cartServices.addToCart(cartItem);
            
            this.toaster.success('Item added to cart!', 'Success');
          }
        
        }
}
