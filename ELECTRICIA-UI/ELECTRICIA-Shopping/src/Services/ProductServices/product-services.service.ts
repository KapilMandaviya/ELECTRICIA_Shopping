import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductServicesService {
    private quickViewProductSource = new BehaviorSubject<any>(null);
  quickViewProduct$ = this.quickViewProductSource.asObservable();

    constructor( private route:Router,public http:HttpClient,@Inject(PLATFORM_ID) private platformId: object) { 
        }

   setQuickViewProduct(product: any) {
    this.quickViewProductSource.next(product);
  }
    public getProductListByProdcutCategory(Id:number): Observable<any[]> {
        return this.http.get<any[]>(`${environment.apiUrl}/ProductDetails/getProductListByProdcutCategory/${Id}`)
      }

        public getProductByProductId(Id:number): Observable<any[]> {
        return this.http.get<any[]>(`${environment.apiUrl}/ProductDetails/getProductByProdcutId/${Id}`)
      }
}
