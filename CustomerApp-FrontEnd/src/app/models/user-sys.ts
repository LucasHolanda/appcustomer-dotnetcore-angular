import { UserRole } from "./user-role";
export class UserSys {
  id: number = 0;
  login: string = '';
  password: string = '';
  userRoleId: number = 0;
  userRole = UserRole;
}
