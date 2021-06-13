import { Component, OnInit } from '@angular/core';
import { Item } from '../model/Cart/item.model';
import { AuthService } from '../shared/auth.service';
import { ShoppingCartService } from '../shared/shopping-cart.service';
import { ActivatedRoute, RouteConfigLoadEnd } from '@angular/router';


@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  shoppingCartItemCount : number=0;
  shoppingCartItems : any=[]
 

  constructor(public authservice: AuthService, 
    private shoppingCartService: ShoppingCartService,
    private route:ActivatedRoute) { }

  ngOnInit() {
    
    this.getCartItems();    
    
  }

  getCartItems()  {
    this.shoppingCartService.getTotalItems().subscribe({
      next : data=>{
        this.shoppingCartItems = data
        //console.log(this.shoppingCartItems)        
        for(let item in this.shoppingCartItems){
          this.shoppingCartItemCount+=this.shoppingCartItems[item]['quantity']
        }
        //console.log('TOTAL ITEMS',this.shoppingCartItemCount)
        
      },
      error : error=>{
        console.log(error);
      }
    })

    
  }

  signOut(): void {
   this.authservice.signOut();
  }  
  
  
}
