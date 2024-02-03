import { Component } from '@angular/core';
import {LoginService} from "./shared/Login-Service/login.service";
import {OrdersService} from "./shared/Order-Service/orders.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';

  constructor(private service: LoginService, public orderservice : OrdersService) {
  }

  isLoggedIn(): boolean {
    return this.service.isLoggedIn();
  }
  isSeller(){
    return localStorage.getItem('token') != null;
  }
  isClient(){
    return localStorage.getItem('token2') != null;

  }
  logout(): void {
    this.orderservice.refreshList()
    this.orderservice.refreshOrderList()
    this.service.logout();
  }
}
