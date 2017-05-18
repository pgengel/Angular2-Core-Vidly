import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MembershipTypeService {

  constructor(private http: Http) { }

  getMembershipType(){
    return this.http.get('/api/customer/new')
      .map(res => res.json());
  }
}
