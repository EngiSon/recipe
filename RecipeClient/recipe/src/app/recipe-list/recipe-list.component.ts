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

  checkBoxes = [{id:0, label:'Default', checked:true},
                {id:1, label:'Vegan', checked:true},
                {id:2, label:'Vegetarian', checked:true},
                {id:3, label:'Pesciterian', checked:true},
                {id:4, label:'Glutenfree', checked:true}]
  userId: number = this.apiSvc.getLoggedInUserId()
  recipes: Recipe[];
  search: string;
  recipeStorage: Recipe[] = [];
  typeFiltered: Recipe[] = [];
  termFiltered: Recipe[] = [];
  foodType: FoodType = new FoodType();

  ngOnInit(): void
  {
    this.getAllRecipes()
  }

  getAllRecipes(): void
  {
    this.apiSvc.getAllRecipes().then(recipes =>
      {
        this.recipes = recipes
        this.recipeStorage = recipes
        this.termFiltered = recipes
        this.typeFiltered = recipes
      });
  }

  handleIntersection(): void
  {
    this.recipeStorage = this.termFiltered.filter(r => this.typeFiltered.some(r2 => r.id == r2.id))
  }

  doSearch(): void
  {
    let filteredRecipes: Recipe[] = []

    filteredRecipes = this.recipes.filter(recipe => recipe.ingredients.includes(this.search));

    this.termFiltered = filteredRecipes

    this.handleIntersection()
  }

  onCheckChange($event): void
  {
    let filteredRecipes: Recipe[] = [];

    this.checkBoxes[$event['path'][0]['id']].checked = $event['path'][0]['checked']

    this.checkBoxes.forEach(cbox =>
    {
      this.recipes.forEach(recipe =>
      {
        if (cbox.checked == true)
        {
          if(recipe.foodType == cbox.id)
          {
            filteredRecipes.push(recipe);
          }
        }
      })
    })

    this.typeFiltered = filteredRecipes

    this.handleIntersection()
  }

  logoutUser(): void
  {
    this.apiSvc.logOutUser()
    window.location.reload()
  }

}
