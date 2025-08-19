import { CommonModule } from '@angular/common';
import { Component, Inject, PLATFORM_ID, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { ProductServicesService } from '../../Services/ProductServices/product-services.service';
import { ToastrService } from 'ngx-toastr';
import { CartService } from '../../Services/Cart-Services/cart.service';
import { CartItem,wishlistItem } from '../../Dto/commonclass/commonclass';
import { WishListService } from '../../Services/Wish-List/wish-list.service';
import { LoginService } from '../../Services/Login/login.service';


@Component({
  selector: 'app-shop-details',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './shop-details.component.html',
  styleUrl: './shop-details.component.css',
  encapsulation: ViewEncapsulation.None // <-- Add this
})
export class ShopDetailsComponent {
 categoryId!: number;
 categoryName!: string;
 products: any[] = [];
   

  
   categories = [
    { name: 'Laptops', count: 22 },
    { name: 'Desktops', count: 18 },
    { name: 'Monitors', count: 12 },
    { name: 'Accessories', count: 30 }
  ];

  priceRanges = [
    { label: 'Under ₹20,000' },
    { label: '₹20,000 – ₹50,000' },
    { label: '₹50,000 – ₹80,000' },
    { label: 'Above ₹80,000' }
  ];

  colors = [
    { id: 'black', name: 'Black' },
    { id: 'silver', name: 'Silver' },
    { id: 'gray', name: 'Gray' },
    { id: 'white', name: 'White' }
  ];

  brands = [
    { id: 'brand1', name: 'Minimalin' },
    { id: 'brand2', name: 'Vendor A' },
    { id: 'brand3', name: 'Vendor B' }
  ];
  constructor(private Services:ProductServicesService,private loginservices:LoginService ,private route:ActivatedRoute, private cartServices:CartService,private WishListServices:WishListService  ,private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
    
    
}   
    

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
    const id = params.get('id');
    const name = params.get('name');
    
     if (name) {
        this.categoryName = name;
      } else {
        this.categoryName = 'Default Category Name'; // Fallback value
      }
    this.categoryId = id ? +id : 0;
    

     this.Services.getProductListByProdcutCategory(this.categoryId).subscribe({
          next: (success:any[]) => {
          this.products = success;
            
             
          },
          error: (error:any) => { console.error('Error fetching product list:', error); }
    // Now fetch data using this.categoryId
  });
    });  
  }

  openQuickView(product: any) {
    console.log(' Product:', this.products);
  this.Services.setQuickViewProduct(product);
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
