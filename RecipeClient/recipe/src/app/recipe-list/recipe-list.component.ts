import { Component, OnInit } from '@angular/core';
import { Recipe } from '../model/Recipe';
import { RecipeApiService } from '../service/recipe-api.service';
import { FoodType } from '../model/FoodType';

@Component({
  selector: 'rec-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.scss']
})
export class RecipeListComponent implements OnInit {

  constructor(private apiSvc: RecipeApiService) { }

  userId: number = this.apiSvc.getLoggedInUserId()
  recipes: Recipe[] | undefined;
  foodType: FoodType = new FoodType();

  ngOnInit(): void {
    this.getAllRecipes()
  }

  getAllRecipes(): void
  {
    this.apiSvc.getAllRecipes().then(recipes => this.recipes = recipes);
  }

  logoutUser(): void
  {
    this.apiSvc.logOutUser()
    window.location.reload()
  }

}
