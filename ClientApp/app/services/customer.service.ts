import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class CustomerService {

  constructor(private http: Http) { }

  getCustomers(){
    this.http.get('/api/customer')
      .map(res => res.json());
  }
}
