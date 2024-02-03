import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductsFormComponent } from './Products/products-form/products-form.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { OrdersComponent } from './orders/orders.component';
import { MakeOrderComponent } from './Orders/make-order/make-order.component';
import {appRoutingModule} from "./app.routing";
import { RegisterSellerComponent } from './Register/register-seller-client/register-seller.component';
import { LoginComponent } from './Login/login/login.component';
import { RegisterComponent } from './Register/register/register.component';
import { ColorDirective } from './color.directive';
import { PriceInRonPipe } from './price-in-ron.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ProductsFormComponent,
    OrdersComponent,
    MakeOrderComponent,
    LoginComponent,
    RegisterComponent,
    ColorDirective,
    PriceInRonPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    appRoutingModule,
    RegisterSellerComponent,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
