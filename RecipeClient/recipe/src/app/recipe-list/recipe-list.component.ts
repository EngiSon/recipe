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

  recipes: Recipe[] | undefined;
  foodType: FoodType = new FoodType();

  ngOnInit(): void {
    this.apiSvc.getAllRecipes().then(recipes => this.recipes = recipes);
  }

}
