import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/shared/account.service';
import { UserSys } from 'src/app/models/user-sys';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  imgAdmin = 'https://res.cloudinary.com/mhmd/image/upload/v1556074849/avatar-1_tcnd60.png'
  imgSeller = 'https://preview.keenthemes.com/metronic-v4/theme/assets/pages/media/users/avatar80_7.jpg';

  constructor(private accountService: AccountService) { }
  user = {} as UserSys;

  ngOnInit() {
    this.user = this.accountService.getAuthorizationUser();
  }

  logout() {
    this.accountService.logout();
  }

}
