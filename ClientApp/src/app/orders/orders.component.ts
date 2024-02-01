import { Component } from '@angular/core';
import {OrdersService} from "../shared/Order-Service/orders.service";
import {NgForm} from "@angular/forms";
import {Products} from "../shared/Product-Service/products.model";
import {Orders} from "../shared/Order-Service/orders.model";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {
  constructor(public service : OrdersService) {

  }
  ngOnInit(): void {
    this.service.refreshList()
    this.service.refreshOrderList()

  }

  onAdd(product_id : number) {
    this.service.postOrder(product_id).subscribe({
      next: res => {this.service.order = res as Orders},
      error: err => {
        console.log(err)
      }
    })
  }


}
