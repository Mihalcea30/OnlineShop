import { Component } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {LoginService} from "../../shared/Login-Service/login.service";
import {OrdersService} from "../../shared/Order-Service/orders.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
constructor(public service: LoginService, public orderservice :OrdersService) {
}
  loginForm = new FormGroup({
      email: new FormControl(""),
      password: new FormControl("")
    }
  );

  loginSubmited(){
    this.service.credentials.email = this.loginForm.value.email
    this.service.credentials.password = this.loginForm.value.password
    this.service.postLogin()
    this.orderservice.refreshOrderList()
    this.orderservice.refreshList()
    //this.service.checkRoles()
  }

}
