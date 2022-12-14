import { Component, OnInit } from '@angular/core';
import { RecipeApiService } from '../service/recipe-api.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../model/User';
import { Router } from '@angular/router';

@Component({
  selector: 'rec-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginUser: User

  userForm: FormGroup = new FormGroup(
    {
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required])
    }
  )

  constructor(
    private apiSvc: RecipeApiService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  async login(): Promise<void>
  {
    const userLogin =
    {
      email: this.userForm.get('email').value,
      password: this.userForm.get('password').value
    }

    await this.apiSvc.validateUser(userLogin).then(user => this.loginUser = user).catch(() =>
    {
      alert('Login failed. Username or password incorrect!')
    })

    if (this.loginUser != undefined)
    {
      this.apiSvc.logInUser(this.loginUser.id)
      this.goBack()
    }
  }

  goBack(): void
  {
    this.router.navigate(['home']);
  }

}
