import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../shared/shopping-cart.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  shoppingCartItemCount : number=0;
  shoppingCartItems : any=[]
  cart : any=[]
  totalPrice : number =0;

  constructor( private shoppingCartService : ShoppingCartService) { }

   ngOnInit() {
    
    this.getCartItems();    
    this.getAll();
  }

  getAll(){
    this.shoppingCartService.getAll().subscribe({
      next:data=>{
        this.cart = data;
        for (let item in this.cart){
          this.totalPrice+=this.cart[item]['quantity']*this.cart[item]['amount']
        }
      }
    })
  }


  getCartItems()  {
    this.shoppingCartService.getTotalItems().subscribe({
      next : data=>{
        this.shoppingCartItems = data
        for(let item in this.shoppingCartItems){
          this.shoppingCartItemCount+=this.shoppingCartItems[item]['quantity']
        }
        
      },
      error : error=>{
        console.log(error);
      }
    })

    
  }

}
