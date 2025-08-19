import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { AboutUs, ApiResponse, BlogServicesDetail, CategoryValue, ContactUs, FAQDetail, ServicesDetail } from '../../Dto/commonclass/commonclass';



@Injectable({
  providedIn: 'root'
})

export class CommonApiService {
   
  constructor(private route: Router, public http: HttpClient, @Inject(PLATFORM_ID) private platformId: object) {
    
  }

 
  public getAboutUs(): Observable<AboutUs[]> {
    return this.http.get<AboutUs[]>(`${environment.apiUrl}/AboutUs/AboutUsDetail`)
  }

  public getContactUs(): Observable<ContactUs[]> {
    return this.http.get<ContactUs[]>(`${environment.apiUrl}/AboutUs/ContactDetail`)
  }

  public getFAQList(): Observable<FAQDetail[]> {
    return this.http.get<FAQDetail[]>(`${environment.apiUrl}/AboutUs/FAQDtails`)
  }

  public getServicesList(): Observable<ServicesDetail[]> {
    return this.http.get<ServicesDetail[]>(`${environment.apiUrl}/AboutUs/ServicesDetails`)
  }

  public getBlogServicesList(): Observable<BlogServicesDetail[]> {
    return this.http.get<BlogServicesDetail[]>(`${environment.apiUrl}/AboutUs/BlogServices`)
  }


  public getBlogDetailById(Id: number): Observable<BlogServicesDetail[]> {

    return this.http.get<BlogServicesDetail[]>(`${environment.apiUrl}/AboutUs/getBlogDetailById/${Id}`)
  }

  public getRecentBlogPost(): Observable<BlogServicesDetail[]> {

    return this.http.get<BlogServicesDetail[]>(`${environment.apiUrl}/AboutUs/getRecentBlogDetails`)
  }

  public getCategoryListForHeader(): Observable<any[]> {
    return this.http.get<any[]>(`${environment.apiUrl}/CategoryDetail/getParentCategoryList`)
  }

}
