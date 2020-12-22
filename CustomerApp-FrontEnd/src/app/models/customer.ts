import { City } from "./city";
import { Classification } from "./classification";
import { Gender } from "./gender";
import { Region } from "./region";
import { UserSys } from "./user-sys";

export class Customer {
  id: number = 0;
  name: String = '';
  phone: String = '';
  lastPurchase: Date | undefined;
  genderId: number = 0;
  cityId: number = 0;
  regionId: number = 0;
  classificationId: number = 0;
  userId: number = 0;
  gender = Gender;
  city = City;
  region = Region;
  classification = Classification;
  user = UserSys;
}
