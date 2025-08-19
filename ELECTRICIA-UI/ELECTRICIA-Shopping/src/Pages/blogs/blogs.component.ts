import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';

import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { ToastrService } from 'ngx-toastr';
import { Comment ,BlogServicesDetail} from '../../Dto/commonclass/commonclass';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-blogs',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './blogs.component.html',
  styleUrl: './blogs.component.css'
})
export class BlogsComponent  {

  Id!: number;
  cmtCount!: number;
  recentBlogs: BlogServicesDetail[]=[] ;
  blogDetails:BlogServicesDetail[] = []; // Initialize as an empty array
  tags: string[] = []; // Array to hold split tags
  constructor(private Services:CommonApiService ,private route:ActivatedRoute, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
        
    this.Services.getRecentBlogPost().subscribe({
      next: (success:BlogServicesDetail[]) => {
      
     
        this.recentBlogs = success.map(item => ({
                blog_Id: item.blog_Id,
                blog_Image: item.blog_Image,
                blog_Caption: item.blog_Caption,
                blog_By: item.blog_By,
                blog_Date: item.blog_Date,
                blog_Description: item.blog_Description,
                blog_Tags: item.blog_Tags,
                comment_date: '', // Not needed in blogDetail
                comment_Description: '',
                cm_Id: 0,
                name: '' ,
                commentCount: 0

        }));
 //  this.recentBlogs  = success ;
      },
    });  
    this.Services.getBlogServicesList().subscribe({
      next: (success:any) => {
        this.blogDetails =success ;
      },
        
    });



        } 

  
}