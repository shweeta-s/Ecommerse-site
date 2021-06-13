import { Component, Input, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/shared/category.service';

@Component({
  selector: 'product-filter',
  templateUrl: './product-filter.component.html',
  styleUrls: ['./product-filter.component.css']
})
export class ProductFilterComponent implements OnInit {
  categories:any=[]
  @Input('category') category;
  constructor(private categoryservice:CategoryService) { }

  ngOnInit(): void {
    this.setCategory()
  }

  setCategory(){
    this.categoryservice.getAll().subscribe( data=>{
      this.categories = data;
    });
  }
}
