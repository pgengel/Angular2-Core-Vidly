import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  private customers : any[];
  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers()
      .subscribe(customers => {
        this.customers = customers;
      });
    
  }

}
