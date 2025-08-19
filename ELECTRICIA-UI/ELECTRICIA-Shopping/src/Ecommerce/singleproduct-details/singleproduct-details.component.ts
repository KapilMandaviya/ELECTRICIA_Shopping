import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ProductServicesService } from '../../Services/ProductServices/product-services.service';
import { ToastrService } from 'ngx-toastr';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { CartItem, ContactUs, FAQDetail, wishlistItem } from '../../Dto/commonclass/commonclass';
import { WishListService } from '../../Services/Wish-List/wish-list.service';
import { LoginService } from '../../Services/Login/login.service';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';


@Component({
  selector: 'app-singleproduct-details',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './singleproduct-details.component.html',
  styleUrl: './singleproduct-details.component.css'
})
export class SingleproductDetailsComponent {
 productname!: string;
 productid!: number | null;
  
 products: any = {}; 
 faqdetails:FAQDetail[]=[]; // Initialize as an empty array 
 contacts: ContactUs[] = []; // Initialize as an empty array
  constructor(private Services:ProductServicesService,private CommonServices:CommonApiService,private loginservices:LoginService ,private cartServices:CartService ,private WishListServices:WishListService  ,private route:ActivatedRoute, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object,private router:Router) {
    if (isPlatformBrowser(this.platformId)) {
        this.CommonServices.getFAQList().subscribe({
          next: (success:any) => {
            this.faqdetails =success ;
          },
        });
      };   
      
      if (isPlatformBrowser(this.platformId)) {
      this.CommonServices.getContactUs().subscribe({
        next: (success:any) => {
        
          this.contacts =success ;
          
        },
          
      });
      
    };
      
      
  } 

  buyNow(product: any) {
      // Save cart items to service
  this.cartServices.cartItems = this.products;

  // Navigate to payment page
  this.router.navigate(['payment-detail']);
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
     const id = params.get('id');
    const name = params.get('name');
    
     if (name) {
        this.productname = name;
      } else {
        this.productname = 'Default Category Name'; // Fallback value
      }
    this.productid = id ? +id : 0;
    

     this.Services.getProductByProductId(this.productid).subscribe({
          next: (success:any[]) => {
          this.products = success;
         
             
          },
          error: (error:any) => { console.error('Error fetching product list:', error); }
    // Now fetch data using this.categoryId
    });

    });  
   }

  addToCart(product: any)  {
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
    // Check if the item already exists in the cart
    // If it exists, show a warning; if not, add it to the cart
    if (existingItem.length > 0) {
      // Item already in cart
      this.toaster.warning('Item already in cart!', 'Warning');
    } else {
      // Add new item to cart
      this.cartServices.addToCart(cartItem);    
    }
  
  }
  addToWishlist(product: any) {
  if (!product || !product.productId || !product.pName || !product.img_Name || !product.pBasePrice) {
    this.toaster.error('Invalid product details');
    return;     
  }
  const wishlistItem: wishlistItem = {
    // categoryId: product.categoryId, // Assuming product has a categoryId property
    // categoryName: product.categoryName, // Assuming product has a categoryName property
    productId: product.productId,
    productName: product.pName,
    imageUrl: product.img_Name,
    price: product.pBasePrice,
    quantity: 1,
    totalPrice: product.pBasePrice * 1 // Assuming quantity is 1 for now
    
  };
   var existingItem = this.WishListServices.getwishlist().filter(item => item.productId == wishlistItem.productId);
    
    if (existingItem.length > 0) {
      // Item already in cart
      this.toaster.warning('Item already in wishlist!', 'Warning');
    } else {
      // Add new item to cart
      this.WishListServices.addTowishlist(wishlistItem);
      

      this.toaster.success('Item added to wishlist!', 'Success');
    }
  
}

 

}

 