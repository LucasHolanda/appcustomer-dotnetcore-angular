import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerItemListComponent } from './customer-list/customer-item-list.component';
import { CustomerAddComponent } from './customer-add/customer-add.component';

import { CustomerRoutingModule } from './customer-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { TextMaskModule } from 'angular2-text-mask';
import { NgBrazil } from 'ng-brazil';

@NgModule({
    declarations: [
        CustomerListComponent,
        CustomerItemListComponent,
        CustomerAddComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        CustomFormsModule,
        CustomerRoutingModule,
        NgBrazil,
        TextMaskModule,
    ],
    exports: []
})

export class CustomerModule { }