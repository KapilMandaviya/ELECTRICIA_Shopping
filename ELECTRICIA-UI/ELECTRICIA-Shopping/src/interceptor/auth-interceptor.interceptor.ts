// auth-interceptor.interceptor.ts
import { HttpErrorResponse, HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoginService } from '../Services/Login/login.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { LoginDetail } from '../Dto/login-detail';

export const tokenInterceptor: HttpInterceptorFn = (request: HttpRequest<any>, next: HttpHandlerFn): Observable<HttpEvent<any>> => {
  const empService = inject(LoginService);
  const toast = inject(ToastrService);
  const router = inject(Router);

  const myToken = empService.getToken();
  
  // Clone request with token if it exists
  if (myToken) {
    request = request.clone({
      setHeaders: { Authorization: `Bearer ${myToken}` },
    });
  }

  return next(request).pipe(
    catchError((err: any) => {
      if (err instanceof HttpErrorResponse && err.status === 401) {
        

        const tokenApiModel = new LoginDetail();
        tokenApiModel.token = empService.getToken() ?? '';
        tokenApiModel.refreshToken = empService.getRefreshToken() ?? '';

        return empService.renewToken(tokenApiModel).pipe(
          switchMap((emp: LoginDetail) => {
        
            empService.storeRefreshToken(emp.refreshToken);
            empService.setToken(emp.token);
            const retryRequest = request.clone({
              setHeaders: { Authorization: `Bearer ${emp.token}` },
            });
            return next(retryRequest);
          }),
          catchError((refreshErr) => {
            
            toast.warning('Token is expired, please login again', 'Error');
            router.navigate(['account-auth']);
             localStorage.removeItem("token");
            localStorage.removeItem("refreshToken");
            // Return an empty observable to prevent further error propagation
            return new Observable<HttpEvent<any>>((subscriber) => subscriber.complete());
          })
        );
      }
      // For non-401 errors, rethrow to let the caller handle it
      return throwError(() => err);
    })
  );
};