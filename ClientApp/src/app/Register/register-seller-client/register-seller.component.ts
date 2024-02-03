import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {SellerService} from "../../shared/Seller-Service/seller.service";
import {Seller} from "../../shared/Seller-Service/seller.model";
import {OrdersService} from "../../shared/Order-Service/orders.service";
import {ActivatedRoute} from "@angular/router";
import {ClientService} from "../../shared/Client-Service/client.service";

@Component({
  selector: 'app-register-seller-client',
  templateUrl: './register-seller.component.html',
  styleUrls: ['./register-seller.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule]
})
export class RegisterSellerComponent implements OnInit{
  userType: string = "";
  constructor(public service : SellerService, public orderservice : OrdersService, private route : ActivatedRoute, public clientservice:ClientService) {
  }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userType = params['type'];
    });
  }
  registerForm = new FormGroup({
    name: new FormControl(""),
    adress: new FormControl(""),
    email: new FormControl(""),
    password: new FormControl("")
  }
  );
  registerSubmited(){

    this.service.seller.seller_Name = this.registerForm.value.name
    this.service.seller.address = this.registerForm.value.adress
    this.service.seller.password = this.registerForm.value.password
    this.service.seller.email = this.registerForm.value.email

    this.clientservice.client.client_Name = this.registerForm.value.name
    this.clientservice.client.address = this.registerForm.value.adress
    this.clientservice.client.password = this.registerForm.value.password
    this.clientservice.client.email = this.registerForm.value.email

    if(this.userType == 'seller')
      this.service.postSeller()
    else
      this.clientservice.postClient()
    this.orderservice.refreshOrderList()
  }



}
