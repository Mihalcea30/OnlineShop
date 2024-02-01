import {Component, OnInit} from '@angular/core';
import {ProductsService} from "../shared/Product-Service/products.service";
import {Products} from "../shared/Product-Service/products.model";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit{
  constructor(public service : ProductsService) {
  }

  ngOnInit(): void {
    this.service.refreshList()
  }
  populateForm(selectorRecord: Products){
    this.service.formData = Object.assign({},selectorRecord)

  }
  onDelete(id:number){
    if(confirm('Are you sure?'))
    this.service.deleteProduct(id).subscribe({
      next:res =>{this.service.list = res as Products[]
        },
      error:err => {console.log(err)}
    })

  }
}
