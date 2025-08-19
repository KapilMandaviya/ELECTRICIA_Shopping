import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
     constructor( private route:Router,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object ) 
     { 
      }

       public getTopDiscountProduct(): Observable<any[]> {
        
          return this.http.get<any[]>(`${environment.apiUrl}/Home/getTopDiscountProduct`)
        }

         public GET_TopFeauteredProduct(): Observable<any[]> {
        
          return this.http.get<any[]>(`${environment.apiUrl}/Home/GET_TopFeauteredProduct`)
        }
 
        public GET_TopNewArrivalProducts(): Observable<any[]> {
        
          return this.http.get<any[]>(`${environment.apiUrl}/Home/GET_TopNewArrivalProducts`)
        }

      }
