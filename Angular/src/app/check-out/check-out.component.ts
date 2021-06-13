import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.css']
})
export class CheckOutComponent implements OnInit {
  profileForm = new FormGroup({
    name: new FormControl(''),
    addrLine1: new FormControl(''),
    addrLine2: new FormControl(''),
    city: new FormControl('')  
  });
  
  constructor() { }

    
  

  ngOnInit(): void {
  }

  onSubmit() {
    console.warn(this.profileForm.value);
  }

}
