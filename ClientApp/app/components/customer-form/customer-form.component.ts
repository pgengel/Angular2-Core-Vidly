import {ToastyService} from 'ng2-toasty';
import { MembershipTypeService } from './../../services/membership-type.service';
import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  private membershipType : any[];
  private typeOfMembership : any = {};
  private isSubscribed : boolean = false; 
  private customerName : string = "";
  private subscription : any = {
    Name : "",
    isSubscribedToNewsLetter: false,
    MembershipType: {},
    // Birthday: ""
  };

  constructor(private membershipTypeService: MembershipTypeService, private customerService: CustomerService, private  toastyService: ToastyService) { }

  ngOnInit() {
    this.membershipTypeService.getMembershipType()
      .subscribe(m => this.membershipType = m);
  }
  
  onMembershipTypeSelect(){
   var selectedMembershipType = this.membershipType.find(m => m.id == this.typeOfMembership.id);
   console.log(selectedMembershipType);
  }

  submit(){
    console.log(this.subscription);
    this.customerService.createCustomer(this.subscription)
        .subscribe(c =>
            c.console.log(this.subscription),
            err => {
              this.toastyService.error({title: "Error", msg: "Anunexpected error happened", theme: "bootstrap", showClose: true, timeout: 5000})
            });
  }
}
