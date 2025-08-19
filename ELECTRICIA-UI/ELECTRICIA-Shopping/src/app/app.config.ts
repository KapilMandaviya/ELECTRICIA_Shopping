import { APP_ID, ApplicationConfig, PLATFORM_ID, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, RouterConfigOptions } from '@angular/router';
import { routes } from './app.routes';
import { provideServerRendering } from '@angular/platform-server';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { tokenInterceptor } from '../interceptor/auth-interceptor.interceptor';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
  
export const appConfig: ApplicationConfig = {
  
  
  providers: [
   
  provideZoneChangeDetection({ eventCoalescing: true }),
  provideServerRendering(),
 
  
  provideRouter(routes), // Provide the routes for the application
  provideHttpClient(
    withFetch(), // Use fetch backend
    
    withInterceptors([tokenInterceptor]) // Add a global interceptor
  ),
  provideAnimations(),
  provideToastr({
    timeOut: 3000,
    positionClass: 'toast-top-right',
    preventDuplicates: true
  }),
  { provide: PLATFORM_ID, useValue: 'browser' }, // Default to browser, overridden by SSR
  { provide: APP_ID, useValue: 'electricia-shopping' } // Unique app ID
]

  
  
};


 