import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Customer } from "src/app/models/customer";

@Component({
    selector: "[customer-item-list]",
    templateUrl: "./customer-item-list.component.html"
})

export class CustomerItemListComponent {
    @Input()
    customer = Customer;
    @Input()
    userRoleId: number;

    @Output()
    status: EventEmitter<any> = new EventEmitter();

    sendEvent() {
        this.status.emit(this.customer);
    }
}