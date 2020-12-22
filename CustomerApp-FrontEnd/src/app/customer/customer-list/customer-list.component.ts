import { Component, OnInit } from '@angular/core';
import { FilterCustomer } from 'src/app/models/filter-customer';
import { CustomerService } from '../shared/customer.service';
import { City } from 'src/app/models/city';
import { UserSysService } from '../shared/user-sys.service';
import { Gender } from 'src/app/models/gender';
import { Region } from 'src/app/models/region';
import { Classification } from 'src/app/models/classification';
import { UserSys } from 'src/app/models/user-sys';
import { AccountService } from 'src/app/account/shared/account.service';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/models/customer';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  user = {} as UserSys;
  loadingCustomers = false;

  reqFilter = {} as FilterCustomer;
  cities: City[] = [];
  citiesMain: City[] = [];
  regions: Region[] = [];
  regionsMain: Region[] = [];
  genders: Gender[] = [];
  classifications: Classification[] = [];
  usersSellers: UserSys[] = [];
  customers: Customer[] = [];

  constructor(private customerService: CustomerService
    , private userSysService: UserSysService
    , private accountService: AccountService) { }

  ngOnInit(): void {
    this.user = this.accountService.getAuthorizationUser();
    this.resetObjFilter();
    this.getCommonAll();

    if (this.accountService.isUserAdmin()) {
      this.getAll();
    }
    else {
      this.reqFilter = {} as FilterCustomer;
      this.reqFilter.userId = this.user.id;

      this.filter(this.reqFilter);
    }
  }

  resetObjFilter() {
    this.reqFilter = {} as FilterCustomer;
  }

  getAll() {
    this.loadingCustomers = true;
    this.customerService.getAllInclude().subscribe(response => {
      this.loadingCustomers = false;
      this.customers = response;
    });
  }

  filter(filterCustomer: FilterCustomer) {
    this.loadingCustomers = true;
    this.customerService.filterAllInclude(filterCustomer).subscribe(response => {
      this.loadingCustomers = false;
      this.customers = response;
    });
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

    this.userSysService.getAll().subscribe(response => {
      this.usersSellers = response;
      this.usersSellers = this.usersSellers.filter(usr => { return usr.id != 1 });
    });
  }

  changeRegion(regionId: number) {
    this.cities = [... this.citiesMain];
    if (regionId) {
      this.cities = [... this.citiesMain.filter(city => {
        return city.regionId == regionId;
      })]
    }
  }

  changeCities(cityId: number) {
    this.regions = [... this.regionsMain];

    if (cityId) {
      const citySelected = this.cities.find(city => {
        return city.id == cityId;
      });

      if (citySelected)
        this.reqFilter.regionId = citySelected.regionId;
    }
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    form.resetForm();
    this.reqFilter = {} as FilterCustomer;
    if (this.user.userRoleId !== 1)
      this.reqFilter.userId = this.user.id;
  }
}
