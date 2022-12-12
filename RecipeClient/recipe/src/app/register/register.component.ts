import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RecipeApiService } from '../service/recipe-api.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'rec-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  userForm: FormGroup = new FormGroup(
    {
      username: new FormControl('', [Validators.required, , Validators.minLength(3)]),
      password: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.minLength(3)])
    }
  )

  constructor(
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  ngOnInit(): void {
  }

  register(): void
  {
    const newUser =
    {
      id: 0,
      username: this.userForm.get('username').value,
      password: this.userForm.get('password').value,
      email: this.userForm.get('email').value
    }
    this.apiSvc.addNewUser(newUser)
    this.goBack()
  }

  goBack(): void
  {
    this.location.back()
  }

}
