import { Component, Input, OnInit } from '@angular/core';
import { Cart } from '../model/Cart/cart.model';
import { Product } from '../model/Product/product.model';
import { ShoppingCartService } from '../shared/shopping-cart.service';

@Component({
  selector: 'product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent  {
  @Input('product') product:any=[]
  @Input('item') item;

  quantity : number;


  constructor(private cartservice : ShoppingCartService) { }

  ngOnInit(): void {
    this.quantity = this.getQuantity();
    
  }

  addToCart(){    
    this.cartservice.addToCart(this.product);
  }

  removeFromCart(){
    this.cartservice.removeFromCart(this.product);
  }

  getQuantity() : number{
    
  this.cartservice.getQuantity(this.product).subscribe({
      next: data=>{
       console.log('quantity : ', data.quantity)
       this.quantity =  data.quantity;
       
      },
      error: error => {        
        //console.error('There was an error!', error);
        console.log('quantity',0)
        this.quantity= 0
    }
    })
   
    return this.quantity
    
  }

}
