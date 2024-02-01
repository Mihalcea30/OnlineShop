import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

import {Products} from "./products.model";
import {environment} from "../../../environments/environment.development";
import {NgForm} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  url:string = environment.apiBaseurl+ '/Products'
  list:Products[] = []
  formData : Products = new Products()
  constructor(private http: HttpClient) { }
  refreshList(){
    this.http.get(this.url)
      .subscribe({
        next : res => {this.list = res as Products[]},
        error : err => {console.log(err)}
      })
  }
  postProduct(){
    return this.http.post(this.url,this.formData)
  }
  putProduct(){
    return this.http.put(this.url + '/' + this.formData.product_Id,this.formData)
  }
  deleteProduct(id:number){
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form : NgForm){
    form.form.reset()
    this.formData = new Products()

  }
}
