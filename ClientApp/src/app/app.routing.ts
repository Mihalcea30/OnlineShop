import { Routes, RouterModule } from '@angular/router';
import {ProductsComponent} from "./products/products.component";
import {OrdersComponent} from "./orders/orders.component";
import {RegisterSellerComponent} from "./Register/register-seller-client/register-seller.component";
import {LoginComponent} from "./Login/login/login.component";
import {RegisterComponent} from "./Register/register/register.component";
import {authGuard} from "./Guard/auth.guard";
import {auth2Guard} from "./Guard/auth2.guard";



const routes: Routes = [
  { path: 'order', component: OrdersComponent , canActivate:[auth2Guard]},
  { path: 'product', component: ProductsComponent, canActivate:[authGuard] },
  //{path : 'register', component: RegisterComponent},
  {path : 'login', component: LoginComponent},
  { path: 'register/:type', component: RegisterSellerComponent },
  //{ path: 'register/client', component: RegisterComponent },
  //{ path: 'register/seller', component: RegisterSellerComponent },


  // otherwise redirect to home
  { path: '**', component: RegisterComponent }
];

export const appRoutingModule = RouterModule.forRoot(routes);
