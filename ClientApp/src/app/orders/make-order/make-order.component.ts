import { Component } from '@angular/core';
import {OrdersService} from "../../shared/Order-Service/orders.service";

@Component({
  selector: 'app-make-order',
  templateUrl: './make-order.component.html',
  styleUrls: ['./make-order.component.css']
})
export class MakeOrderComponent {

  constructor(public service : OrdersService) {

  }

  ngOnInit(): void {
    this.service.refreshOrderList()


  }

}
