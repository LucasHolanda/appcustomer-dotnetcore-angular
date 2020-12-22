import { Customer } from "./customer";

export class FilterCustomer {
  dateStart: Date | undefined;
  dateEnd: Date | undefined;
  name: String = '';
  phone: String = '';
  lastPurchase: Date | undefined;
  genderId: number = 0;
  cityId: number = 0;
  regionId: number = 0;
  classificationId: number = 0;
  userId: number = 0;
}
