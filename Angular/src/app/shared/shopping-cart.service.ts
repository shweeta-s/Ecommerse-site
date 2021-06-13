import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../model/Cart/cart.model';
import { Product } from '../model/Product/product.model';
import { Item } from '../model/Cart/item.model';


@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  readonly rootUrl = 'http://localhost:22609/api';
  
  
  constructor(private http : HttpClient) { }
  

  async getCart(){
      return localStorage.getItem('cart_id')
    }


  create(){     
     
      let cart = new Cart();
      let  ob =  this.http.post<Cart>(this.rootUrl+'/cart',cart)
      return ob
    }

  private async getOrCreateCart(){
    let cart_id= localStorage.getItem('cart_id');
    if (cart_id) return cart_id ; 
    
    let result = this.create()
    result.subscribe(val => localStorage.setItem('cart_id',String(val.cart_id)));
    
    
  } 
 
  async addToCart(product : Product){
    let cartId = await this.getOrCreateCart();    
    cartId = localStorage.getItem('cart_id');
    let reqHeaders = new HttpHeaders().set('Content-Type','application/json');
    return this.http.put<Cart>(this.rootUrl+'/cart/'+cartId+'?action=add', product,{headers:reqHeaders}).subscribe();
       
  }

  async removeFromCart(product : Product){
    let cartId = await this.getOrCreateCart();    
    cartId = localStorage.getItem('cart_id');
    let reqHeaders = new HttpHeaders().set('Content-Type','application/json');
    return this.http.put<Cart>(this.rootUrl+'/cart/'+cartId+'?action=remove', product,{headers:reqHeaders}).subscribe();
  }

  getQuantity(product : Product){
    let cartId = localStorage.getItem('cart_id');   
    return this.http.get<Item>(this.rootUrl+'/cart/'+cartId+','+product.product_id);
  }
  
  getTotalItems(){
    let cartId = localStorage.getItem('cart_id');   
    return this.http.get<Item>(this.rootUrl+'/Item/'+cartId)
  }

  getAll(){
    return this.http.get(this.rootUrl+'/Item')
  }

}
