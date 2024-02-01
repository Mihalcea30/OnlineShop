import { Component } from '@angular/core';
import {ProductsService} from "../../shared/Product-Service/products.service";
import {NgForm} from "@angular/forms";
import {Products} from "../../shared/Product-Service/products.model";

@Component({
  selector: 'app-products-form',
  templateUrl: './products-form.component.html',
  styleUrls: ['./products-form.component.css']
})
export class ProductsFormComponent {
  constructor(public service : ProductsService) {
  }
  onSubmit(form:NgForm){
    if(this.service.formData.product_Id == 0)
      this.insertRecord(form)
    else
      this.updateRecord(form)
  }
  insertRecord(form:NgForm){
    this.service.postProduct().subscribe({
      next:res =>{this.service.list = res as Products[]
        this.service.resetForm(form)},
      error:err => {console.log(err)}
    })

  }
  updateRecord(form:NgForm){
    this.service.putProduct().subscribe({
      next:res =>{this.service.list = res as Products[]
        this.service.resetForm(form)},
      error:err => {console.log(err)}
    })

  }
}
