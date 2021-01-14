import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgBrazilValidators } from 'ng-brazil';
import { utilsBr } from 'js-brasil';
import { Customer } from 'src/app/models/customer';
import { AccountService } from 'src/app/account/shared/account.service';
import { CustomerService } from '../../shared/customer.service';
import { UserSys } from 'src/app/models/user-sys';
import { City } from 'src/app/models/city';
import { Region } from 'src/app/models/region';
import { Gender } from 'src/app/models/gender';
import { Classification } from 'src/app/models/classification';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {
  user = {} as UserSys;

  cities: City[] = [];
  citiesMain: City[] = [];
  regions: Region[] = [];
  regionsMain: Region[] = [];
  genders: Gender[] = [];
  classifications: Classification[] = [];

  customerForm: FormGroup;
  customer: Customer;
  MASKS = utilsBr.MASKS;

  constructor(private customerService: CustomerService
    , private accountService: AccountService
    , private fb: FormBuilder) { }

  ngOnInit(): void {
    this.user = this.accountService.getAuthorizationUser();
    this.getCommonAll();

    this.customerForm = this.fb.group({
      name: ['', Validators.required],
      phone: ['', [Validators.required, NgBrazilValidators.celular]],
      genderId: ['', [Validators.required, Validators.min(1)]],
      cityId: ['', [Validators.required, Validators.min(1)]],
      regionId: ['', [Validators.required, Validators.min(1)]],
      classificationId: ['', [Validators.required, Validators.min(1)]],
    })

    /*
  name: String = '';
  phone: String = '';
  lastPurchase: Date | undefined;
  genderId: number = 0;
  cityId: number = 0;
  regionId: number = 0;
  classificationId: number = 0;
  userId: number = 0;
    */

  }

  addCustomer(): void {
    this.customer = Object.assign({}, this.customer, this.customerForm.value);
    this.customer.userId = this.user.id;
    console.log(this.customer);
  }

  getCommonAll() {
    this.customerService.getCommonAll().subscribe(response => {
      this.cities = response.data.cities;
      this.citiesMain = [... this.cities];
      this.regions = response.data.regions;
      this.regionsMain = [... this.regions];
      this.genders = response.data.genders;
      this.classifications = response.data.classifications;
    });
  }

  changeRegion() {
    const { regionId } = this.customerForm.value;
    this.cities = [... this.citiesMain];
    if (regionId) {
      this.cities = [... this.citiesMain.filter(city => {
        return city.regionId == regionId;
      })]
    }
  }

  changeCities() {
    const { cityId } = this.customerForm.value;
    this.regions = [... this.regionsMain];

    if (cityId) {
      const citySelected = this.cities.find(city => {
        return city.id == cityId;
      });

      if (citySelected)
        this.customerForm.value.regionId = citySelected.regionId;
    }
  }

  isInvalidForm(fcName: string, typeValidate: string = ''): any {
    const isFormInvalid = this.customerForm.invalid;
    const isDirtyOrTouched = (this.customerForm.get(fcName)?.dirty || this.customerForm.get(fcName)?.touched);
    const hasErrors = this.customerForm.get(fcName)?.errors;
    const hasTypeError = this.customerForm.get(fcName)?.getError(typeValidate);

    if (fcName === 'form') return isFormInvalid;

    if (typeValidate) {
      return hasTypeError && isDirtyOrTouched;
    }

    return hasErrors && isDirtyOrTouched;
  }
}
