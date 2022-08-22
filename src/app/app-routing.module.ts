import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from '../app/components/customer/customer.component';
import { HomeComponent } from './components/home/home.component';
import { LicenseComponent } from './components/license/license.component';
import { ProductComponent } from './components/product/product.component';


const routes: Routes = [
  {path:'customer', component: CustomerComponent},
  {path:'product', component: ProductComponent},
  {path:'license', component: LicenseComponent},
  {path:'home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
