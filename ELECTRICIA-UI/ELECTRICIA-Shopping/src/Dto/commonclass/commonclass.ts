

export class AboutUs {
    AbId!:number
    AboutHeader!:string
    AboutDescription!:string
    CreatedByUserId!:number
}

   
export class ContactUs {
    id!: number;
    emailAddress!: string;
    phoneNumber!: string;
    officeAddress!: string; 
}

export class FAQDetail {
    id!: number;
    faqQuestion!: string;
    faqAnswer!: string;
}

export class ServicesDetail {
    serviceId!: number;
    serviceCaption!: string;
    serviceDetail1!: string;
    serviceLink!: string;
}

export class BlogServicesDetail {
    blog_Id!: number;
    blog_Image!: string;
    blog_Caption!: string;
    blog_By!: string;
    blog_Date!: string;
    blog_Description!: string;
    blog_Tags!: string;
    comment_date!: string;
    comment_Description!: string;
    cm_Id!: number;
    name!: string;
    commentCount!: number;
}

// Optional: Separate comment DTO for clarity
export class Comment {
    cm_Id!: number;
    comment_date!: string;
    comment_Description!: string;
    name!: string;
   
  }

export interface CartItem {
  // Define the properties of a cart item
  // Adjust the types as necessary based on your application
  // categoryId: number;
  // categoryName?: string; // Optional if not always available
  productId: number;
  productName: string;
  price: number;
  quantity: number;
  imageUrl: string;
  totalPrice: number;
  // Add more fields as needed (e.g. SKU, description)
}

export interface wishlistItem {
  // Define the properties of a cart item
  // Adjust the types as necessary based on your application
  // categoryId: number;
  // categoryName?: string; // Optional if not always available
  productId: number;
  productName: string;
  price: number;
  quantity: number;
  imageUrl: string;
  totalPrice: number;
  // Add more fields as needed (e.g. SKU, description)
}

  // category.interface.ts
export interface CategoryItem {
    Cat_Name: string;
  }
  
  export interface CategoryValue {
    Key: string;
    Value: CategoryItem[];
  }
  
  export interface ApiResponse {
    categoriesId: number;
    pC_Id: number | null;
    pC_Name: string | null;
    cat_Name: string; // This will be parsed as CategoryValue[]
    createdDate: string | null;
    createdByUserId: number | null;
    updatedDate: string | null;
    deletedDate: string | null;
    isDelete: boolean | null;
    modifyAction: string | null;
  }