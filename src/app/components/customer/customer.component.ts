import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Customer } from 'src/app/models/customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  customers: Customer[] = [];
  
  customerName = "";
  customerEmail = "";
  

  constructor(private customerService: CustomerService) { }

  onChangeHandler(event: Event) {
    const value = (event as CustomEvent).detail.value;
  }

  ngOnInit(): void {
    this.customerService
        .getCustomers()
        .subscribe(data => (this.customers = data))
  }

  addCustomer(){
    var customerAttributes={
      name: this.customerName,
      email: this.customerEmail
    };
    this.customerService.createCustomer(customerAttributes)
                        .subscribe(result => {alert(result.toString())});
    window.location.reload;
  }

  deleteCustomer(customer: Customer){
    this.customerService.deleteCustomer(customer)
                        .subscribe(result => {alert(result.toString())});
    window.location.reload;
  }
  
}
