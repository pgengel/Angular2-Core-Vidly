import * as _ from 'underscore';
import {ActivatedRoute, Router} from '@angular/router';
import {ToastyService} from 'ng2-toasty';
import { MembershipTypeService } from './../../services/membership-type.service';
import { CustomerService } from './../../services/customer.service';
import { Component, OnInit } from '@angular/core';
import 'rxjs/add/Observable/forkJoin';
import { Observable } from "rxjs/Observable";
import { SaveSubscription, Subscription } from "../../models/customer";

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
  private subscription : SaveSubscription = {
    id : 0,
    Name : "",
    isSubscribedToNewsLetter: false,
    MembershipType: {
      payAsYouGo: -1,
      monthly: -1,
      quartly: -1,
      yearly: -1
    },
    // Birthday: ""
  };

  constructor(private membershipTypeService: MembershipTypeService, 
    private customerService: CustomerService, 
    private toastyService: ToastyService,
    private router: Router,
    private route: ActivatedRoute) { 
      route.params.subscribe(p => this.subscription.id = +p['id'])
    }
  ngOnInit() {
    // this.customerService.getCustomer(this.subscription.id>0)
    //   .subscribe(c => this.subscription = c,
    //      err => {   
    //       if (err.status == 404)
    //         this.router.navigate(['/home']);
    //     });

    this.membershipTypeService.getMembershipType()
      .subscribe(m => this.membershipType = m);
  }
  
  private setCustomer(c : Subscription){
    this.subscription.id = c.id;  
    this.subscription.Name = c.name;
    this.subscription.isSubscribedToNewsLetter = c.isSubscribedToNewsLetter;  
    this.subscription.MembershipType = c.membershipType;  
  }
  
  onMembershipTypeSelect(){
    this.populateMembershipType();
  }

  private populateMembershipType(){
    var selectedMembershipType = this.membershipType.find(m => m.id == this.typeOfMembership.id);
    console.log(selectedMembershipType);
  }

  submit(){
    if (this.subscription.id) {
      this.customerService.updateCustomer(this.subscription)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The customer has been successfully updated',
            theme: 'bootstrap',
            timeout: 5000
          });
        });
    }
    else{
      console.log(this.subscription);
      this.customerService.createCustomer(this.subscription)
          .subscribe(x => console.log(x));
    }
  }

  deleteCustomer(id){
    if (confirm("Are you sure")) {
      this.customerService.deleteCustomer(id)
        .subscribe(x => {this.router.navigate(['/home']);
      })
    }
  }
}