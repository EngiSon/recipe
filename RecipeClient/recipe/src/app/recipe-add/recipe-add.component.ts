import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RecipeApiService } from '../service/recipe-api.service';

@Component({
  selector: 'rec-recipe-add',
  templateUrl: './recipe-add.component.html',
  styleUrls: ['./recipe-add.component.scss']
})
export class RecipeAddComponent implements OnInit {

  recipeForm: FormGroup = new FormGroup(
    {
      name: new FormControl('', [Validators.required, , Validators.minLength(3)]),
      foodType: new FormControl(0),
      ingredients: new FormControl('', [Validators.required, Validators.minLength(3)]),
      description: new FormControl('', [Validators.required, Validators.minLength(3)])
    }
  )

  constructor(
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  ngOnInit(): void {
  }

  addNewRecipe(): void
  {
    const recipe =
    {
      id: 0,
      userId: this.apiSvc.getLoggedInUserId(),
      name: this.recipeForm.get('name').value,
      foodType: this.recipeForm.get('foodType').value,
      ingredients: this.recipeForm.get('ingredients').value,
      description: this.recipeForm.get('description').value
    }
    this.apiSvc.addNewRecipe(recipe)
    this.goBack()
  }

  goBack(): void
  {
    this.location.back()
  }

}
