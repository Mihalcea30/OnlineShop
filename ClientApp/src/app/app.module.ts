import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { ProductsFormComponent } from './Products/products-form/products-form.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import { OrdersComponent } from './orders/orders.component';
import { MakeOrderComponent } from './Orders/make-order/make-order.component';
import {appRoutingModule} from "./app.routing";

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    ProductsFormComponent,
    OrdersComponent,
    MakeOrderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    appRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
