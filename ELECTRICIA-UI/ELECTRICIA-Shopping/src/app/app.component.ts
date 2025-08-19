import { Component, Inject, PLATFORM_ID } from '@angular/core';
import {  RouterModule } from '@angular/router';  // Import RouterModule
import  { HeaderComponent} from '../front-end/header/header.component';
import  { FooterComponent } from '../front-end/footer/footer.component';

import { CommonModule } from '@angular/common';
 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule,HeaderComponent,FooterComponent,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  title = 'ELECTRICIA-Shopping';

   
}
