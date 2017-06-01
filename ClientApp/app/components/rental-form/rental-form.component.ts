import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rental-form',
  templateUrl: './rental-form.component.html',
  styleUrls: ['./rental-form.component.css']
})
export class RentalFormComponent implements OnInit {
  isSubscribed : boolean = false;
  customerName : string = "";
  customerMovie : string[] = [];

  constructor() { }

  ngOnInit() {
  }

}
