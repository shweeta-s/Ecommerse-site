import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../shared/shopping-cart.service';

@Component({
  selector: 'shopping-cart-summary',
  templateUrl: './shopping-cart-summary.component.html',
  styleUrls: ['./shopping-cart-summary.component.css']
})
export class ShoppingCartSummaryComponent {
  
  cart : any=[]
  totalPrice : number = 0;
  itemcount : number=0;

  constructor( private shoppingCartService : ShoppingCartService) { }

   ngOnInit() {       
    this.getAll();
  }
  
  getAll(){
    this.shoppingCartService.getAll().subscribe({
      next:data=>{
        this.cart = data;
        for (let item in this.cart){
          this.totalPrice+=this.cart[item]['quantity']*this.cart[item]['amount']
          this.itemcount+= this.cart[item]['quantity']
        }
      }
    })
  }

}
