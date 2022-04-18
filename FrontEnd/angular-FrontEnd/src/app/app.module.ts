import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    NavBarComponent,
    HomeComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([

      { path: "home", component: HomeComponent },
      { path: "signup", component: SignupComponent },
      { path: "products", component: ProductsComponent }
    ]),
  ],
  providers: [],

  bootstrap: [AppComponent]
})
export class AppModule { }
