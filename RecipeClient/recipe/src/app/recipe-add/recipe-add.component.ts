import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from '../model/Recipe';
import { RecipeApiService } from '../service/recipe-api.service';

@Component({
  selector: 'rec-recipe-add',
  templateUrl: './recipe-add.component.html',
  styleUrls: ['./recipe-add.component.scss']
})
export class RecipeAddComponent implements OnInit {

  recipe: Recipe =
  {
    id: 0,
    userId: 1,
    name: "",
    foodType: 0,
    ingredients: "",
    description: ""
  }

  constructor(
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  ngOnInit(): void {
  }

  addNewRecipe(): void
  {
    this.apiSvc.addNewRecipe(this.recipe)
    this.goBack()
  }

  goBack(): void
  {
    this.location.back()
  }

}
