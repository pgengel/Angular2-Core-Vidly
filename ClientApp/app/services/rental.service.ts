import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class RentalService {

  constructor(private http: Http) { }

  getRentals(){
    this.http.get('/api/rentals')
      .map(res => res.json());
  }

}
