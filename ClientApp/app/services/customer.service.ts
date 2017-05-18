import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class CustomerService {

  constructor(private http: Http) { }

  getCustomers(){
    return this.http.get('/api/customers')
      .map(res => res.json());
  }
}
