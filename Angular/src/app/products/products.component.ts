import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ProductService } from '../shared/product.service';
import { ActivatedRoute, RouteConfigLoadEnd } from '@angular/router';
import { ShoppingCartService } from '../shared/shopping-cart.service';

@Component({
  selector: 'products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products:any=[]
  category:number;
  filterProducts:any=[]
  cart : any; 

  constructor(
    private route:ActivatedRoute,
    private shoppingCartServive : ShoppingCartService,
    private productservice : ProductService) { 
    
     
   
  }

  async ngOnInit() {
    this.setCatalog();
    this.cart = await this.shoppingCartServive.getCart()
  }

  setCatalog(){
   

      this.productservice.getAll().subscribe( data=>{
        this.products = data;

        this.route.queryParamMap.subscribe(params =>{
          this.category =Number(params.get('category'));
          
          this.filterProducts=(this.category)?
          this.products.filter(p => p.category_id===this.category):
          this.products;
  
          console.log(this.filterProducts)
        });
        
      });
      
       
  }
}
