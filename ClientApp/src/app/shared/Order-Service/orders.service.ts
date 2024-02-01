import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment.development";
import {Products} from "../Product-Service/products.model";
import {HttpClient} from "@angular/common/http";
import {Orders} from "./orders.model";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  product_url:string = environment.apiBaseurl+ '/Products'
  order_url:string = environment.apiBaseurl+ '/Orders'
  list:Products[] = []
  orderlist:Orders[] = []
  order : Orders = new Orders()

  constructor(private http: HttpClient) { }
  refreshList(){
    this.http.get(this.product_url)
      .subscribe({
        next : res => {this.list = res as Products[]},
        error : err => {console.log(err)}
      })
  }
  refreshOrderList(){
    this.http.get(this.order_url)
      .subscribe({
        next : res => {this.orderlist = res as Orders[]},
        error : err => {console.log(err)}
      })
  }
  postOrder(product_id : number){
  this.order.clientId = 1
    this.order.productId = product_id
    return this.http.post(this.order_url,this.order)

  }

}
