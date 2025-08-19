import { CommonModule, isPlatformBrowser } from '@angular/common';
import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core'; // Include OnInit
import { Route, RouterModule } from '@angular/router';
import { ActivatedRoute } from '@angular/router'; // Correct import
import { ToastrService } from 'ngx-toastr';
import { CommonApiService } from '../../Services/CommonApiServices/common-api.service';
import { BlogServicesDetail,Comment } from '../../Dto/commonclass/commonclass';
@Component({
  selector: 'app-blog-detail',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './blog-detail.component.html',
  styleUrl: './blog-detail.component.css'
})
export class BlogDetailComponent implements OnInit {

  Id!: number;
  cmtCount!: number;
  blogServicesDetail!: BlogServicesDetail | null; // Single blog object
  comments: Comment[] = []; // Array of comments
  tags: string[] = []; // Array to hold split tags
  ngOnInit() {
    this.Id = Number(this.route.snapshot.paramMap.get('blog_Id'));
    // Fetch data using this.blogId (e.g., via service)
    this.Services.getBlogDetailById(this.Id).subscribe({
      next: (success:BlogServicesDetail[]) => {
      
        this.blogServicesDetail = {
          blog_Id: success[0].blog_Id,
          blog_Image: success[0].blog_Image,
          blog_Caption: success[0].blog_Caption,
          blog_By: success[0].blog_By,
          blog_Date: success[0].blog_Date,
          blog_Description: success[0].blog_Description,
          blog_Tags: success[0].blog_Tags,
          comment_date: '', // Not needed in blogDetail
          comment_Description: '',
          cm_Id: 0,
          name: '' ,
          commentCount: 0  
        };
        this.cmtCount = success[0].commentCount || 0;
        
        // Split blog_Tags into an array
        this.tags = success[0].blog_Tags.split(',').map(tag => tag.trim());
        // Extract all comments into a separate array
        this.comments = success.map(item => ({
          cm_Id: item.cm_Id,
          comment_date: item.comment_date,
          comment_Description: item.comment_Description,
          name: item.name
        }));

      
      },
      
        
    });
  }
  constructor(private Services:CommonApiService ,private route:ActivatedRoute, private toaster:ToastrService,@Inject(PLATFORM_ID) private platformId: Object) {
        
        
        } 

  
}
