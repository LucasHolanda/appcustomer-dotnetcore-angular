import { Router } from '@angular/router';
import { AccountService } from './../shared/account.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user = {
    login: '',
    password: ''
  };

  loggingIn = false;
  loginSuccess = false;
  loginError = false;
  loginErrorMessage = '';
  errorApiNotRunning = 'An error occurred while trying to login, check if the API is running, try again'

  constructor(
    private accountService: AccountService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  async onSubmit() {
    try {
      this.loggingIn = true;
      this.accountService.login(this.user).subscribe(response => {
        this.loggingIn = false;
        if (!response.success) {
          this.loginError = true;
          this.loginErrorMessage = response.message;
        }
        else {
          window.localStorage.setItem('token', response.data.token);
          const {id, login, email, userRoleId } = response.data.user;
          window.localStorage.setItem('user', btoa(JSON.stringify({id, login, email, userRoleId })));
          this.loginSuccess = true;
          // navego para a rota vazia novamente
          this.router.navigate(['']);
        }
      }, error => {
        this.loggingIn = false;
        this.loginError = true;
        this.loginErrorMessage = error.message || this.errorApiNotRunning;
      });


    } catch (error) {
      console.log(error);
    }
  }
}
