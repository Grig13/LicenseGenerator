import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: Product[] = [];
  productName="";
  productKey="";
  
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts()
                       .subscribe(data => {this.products = data;})
  }

  addProduct(){
    var productAttributes={
      name: this.productName,
      key: this.productKey
    };
    this.productService.createProduct(productAttributes)
                        .subscribe(result => {alert(result.toString())});
    window.location.reload;
  }

  deleteProduct(product: Product){
    this.productService.deleteProduct(product)
                        .subscribe(result => {alert(result.toString())});
    window.location.reload;
  }

}
