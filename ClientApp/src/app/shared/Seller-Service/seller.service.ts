import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment.development";
import {Products} from "../Product-Service/products.model";
import {HttpClient} from "@angular/common/http";
import {Seller} from "./seller.model";
import {FormGroup} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  url:string = environment.apiBaseurl+ '/Sellers'
  list:Seller[] = []
  seller : Seller = new Seller()
  constructor(private http: HttpClient) { }
  postSeller(){
    return this.http.post(this.url,this.seller).subscribe({
      next : res => {console.log(res)},
      error : err => {console.log(err)}
    })
  }
}
