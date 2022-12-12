import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RecipeApiService } from '../service/recipe-api.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { setCookie } from 'typescript-cookie';
import { User } from '../model/User';

@Component({
  selector: 'rec-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginUser: User

  userForm: FormGroup = new FormGroup(
    {
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
    }
  )

  constructor(
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  ngOnInit(): void {
  }

  async login(): Promise<void>
  {
    const userLogin =
    {
      username: this.userForm.get('username').value,
      password: this.userForm.get('password').value
    }

    console.log(userLogin)

    await this.apiSvc.validateUser(userLogin).then(user => this.loginUser = user).catch(() =>
    {
      alert('Login failed. Username or password incorrect!')
    })

    console.log(this.loginUser)

    if (this.loginUser != undefined)
    {
      this.apiSvc.logInUser(this.loginUser.id)
      this.goBack()
    }
  }

  goBack(): void
  {
    this.location.back()
  }

}
