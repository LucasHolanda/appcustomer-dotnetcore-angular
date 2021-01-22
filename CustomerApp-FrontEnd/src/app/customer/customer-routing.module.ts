import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerAddComponent } from './customer-add/customer-add.component';


const customerRoutes: Routes = [
    {
        path: '',
        component: CustomerListComponent,
    },
    {
        path: 'add',
        component: CustomerAddComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(customerRoutes)],
    exports: [RouterModule]
})
export class CustomerRoutingModule { }
