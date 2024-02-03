import { Routes, RouterModule } from '@angular/router';
import {ProductsComponent} from "./products/products.component";
import {OrdersComponent} from "./orders/orders.component";
import {RegisterSellerComponent} from "./Register/register-seller/register-seller.component";



const routes: Routes = [
  { path: 'order', component: OrdersComponent },
  { path: 'product', component: ProductsComponent },
  {path : 'register', component: RegisterSellerComponent},

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
