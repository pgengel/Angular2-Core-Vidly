import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { SaveSubscription } from "../models/customer";

@Injectable()
export class CustomerService {

  constructor(private http: Http) { }

  getCustomers(){
    return this.http.get('/api/customers')
      .map(res => res.json());
  }

  getCustomer(id){
    return this.http.get('/api/customers/' + id)
      .map(res => res.json());
  }

  createCustomer(subscription){
    return this.http.post("/api/customers", subscription)
      .map(res => res.json());
  }

  updateCustomer(customer : SaveSubscription){
    return this.http.put('/api/customers/' + customer.id, customer)
      .map(res => res.json());
  }

  deleteCustomer(id){
    return this.http.delete('/api/customers/'+ id)
      .map(res => res.json());
  }
}
