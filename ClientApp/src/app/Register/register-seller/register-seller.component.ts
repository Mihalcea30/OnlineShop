import { Component } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {SellerService} from "../../shared/Seller-Service/seller.service";
import {Seller} from "../../shared/Seller-Service/seller.model";

@Component({
  selector: 'app-register-seller',
  templateUrl: './register-seller.component.html',
  styleUrls: ['./register-seller.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule]
})
export class RegisterSellerComponent {
  constructor(public service : SellerService) {
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

    this.service.postProduct()
  }



}
