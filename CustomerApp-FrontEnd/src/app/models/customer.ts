import { City } from "./city";
import { Classification } from "./classification";
import { Gender } from "./gender";
import { Region } from "./region";
import { UserSys } from "./user-sys";

export class Customer {
  id: number;
  name: String;
  phone: String;
  lastPurchase: Date;
  genderId: number;
  cityId: number;
  regionId: number;
  classificationId: number;
  userId: number;
  gender = Gender;
  city = City;
  region = Region;
  classification = Classification;
  user = UserSys;
}
