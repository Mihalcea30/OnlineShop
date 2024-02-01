import { Routes, RouterModule } from '@angular/router';
import {ProductsComponent} from "./products/products.component";
import {OrdersComponent} from "./orders/orders.component";



const routes: Routes = [
  { path: 'order', component: OrdersComponent },
  { path: 'product', component: ProductsComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
