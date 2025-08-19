import { JwtHelperService } from '@auth0/angular-jwt'
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { LoginDetail } from '../../Dto/login-detail';
import { environment } from '../../environments/environment.development';
import { BehaviorSubject, Observable } from 'rxjs';
import { isPlatformBrowser } from '@angular/common';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { WishListService } from '../Wish-List/wish-list.service';
import { CartService } from '../Cart-Services/cart.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  
  constructor( private route:Router,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object,
  ) { 
      }

  private loginUrl="authenticateLogin"
  private userpayload:any;
  private fullname$=new BehaviorSubject<string>("");
  private role$=new BehaviorSubject<string>(""); 

  
   

  loginEmployee(formData: any): Observable<any> {
      return this.http.post(`${environment.apiUrl}/Authentic/${this.loginUrl}`,formData)
  }
  
  setToken(tokenvalue:string){
   
    localStorage.setItem('token',tokenvalue);

  }
  getToken(): string | null {

    if (typeof window !== 'undefined' && window.localStorage) {
      
      
      return localStorage.getItem('token');
    }
    
    return null; // Return null on server-side
  }
  IsLogin():boolean{
  
    if (typeof window !== 'undefined' && window.localStorage) {
      return !!localStorage.getItem('token');
    } else {
      if (typeof window !== 'undefined') {
      
      }
       return false;
    }
   
    //return !!localStorage.getItem('token');

  }
  public getRoleFromStorage()
  {
    return this.role$.asObservable();
  }
  public setRoleFromStore(role:string){
    this.role$.next(role);
  }
  public getNameFromStorage()
  {
    return this.fullname$.asObservable();
  }
  public setNameFromStore(unique_name:string){
    this.fullname$.next(unique_name);
  }

  decodeTokens()
  {
    const jwthelper=new JwtHelperService();
    const token=this.getToken()!;
    
    return jwthelper.decodeToken(token);
  }
  getFullnameFromToken(){
    if(this.userpayload)
      return this.userpayload.unique_name;
  }
  getRoleFromToken(){
    if(this.userpayload)
      return this.userpayload.role;
  }
  storeRefreshToken(token:string)
  {
    localStorage.setItem('refreshToken',token)
  }
  getRefreshToken()
  {
    return localStorage.getItem('refreshToken')
  }

  renewToken(logindetail:LoginDetail){
    return this.http.post<any>(`${environment.apiUrl}/Authentic/refresh`,logindetail)
  }
   
  logout(){
    // localStorage.clear();
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    this.route.navigate(['account-auth']);

  }

 
 


}