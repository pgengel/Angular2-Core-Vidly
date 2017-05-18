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

  constructor(private membershipTypeService: MembershipTypeService) { }

  ngOnInit() {
    this.membershipTypeService.getMembershipType()
      .subscribe(m => this.membershipType = m);
  }
  
  onMembershipTypeSelect(){
   var selectedMembershipType = this.membershipType.find(m => m.id == this.typeOfMembership.id);
   console.log(selectedMembershipType);
  }
}
