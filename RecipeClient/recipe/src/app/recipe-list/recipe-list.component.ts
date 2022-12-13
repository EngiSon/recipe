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
  recipes: Recipe[] | undefined;
  search: string;
  recipeStorage : Recipe[] = [];
  typeFiltered: Recipe[] = [];
  termFiltered: Recipe[] = [];
  foodType: FoodType = new FoodType();

  async ngOnInit(): Promise<void> {
    await new Promise(f => setTimeout(f, 100));
    this.getAllRecipes()
  }

  getAllRecipes(): void
  {
    this.apiSvc.getAllRecipes().then(recipes => this.recipes = recipes);
  }

  doSearch(): void
  {
    let filteredRecipes: Recipe[] = [];
    if(this.recipeStorage.length > 0)
    {
      this.recipes = JSON.parse(JSON.stringify(this.recipeStorage))
    }
    if(this.typeFiltered.length > 0)
    {
      this.recipes = JSON.parse(JSON.stringify(this.typeFiltered))
    }

    filteredRecipes = this.recipes.filter(recipe => recipe.ingredients.includes(this.search));

    this.recipeStorage = JSON.parse(JSON.stringify(this.recipes));
    this.termFiltered = JSON.parse(JSON.stringify(filteredRecipes));
    this.recipes = JSON.parse(JSON.stringify(filteredRecipes));
  }
  onCheckChange($event): void
  {
    let filteredRecipes: Recipe[] = [];

    if(this.recipeStorage.length > 0)
    {
      this.recipes = JSON.parse(JSON.stringify(this.recipeStorage))
    }
    if(this.termFiltered.length > 0)
    {
      this.recipes = JSON.parse(JSON.stringify(this.termFiltered))
    }

    this.checkBoxes[$event['path'][0]['id']].checked = $event['path'][0]['checked']

    this.checkBoxes.forEach(cbox =>
    {
      this.recipes.forEach( recipe =>
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
    this.recipeStorage = JSON.parse(JSON.stringify(this.recipes));
    this.typeFiltered = JSON.parse(JSON.stringify(filteredRecipes));
    this.recipes = JSON.parse(JSON.stringify(filteredRecipes));
  }

  logoutUser(): void
  {
    this.apiSvc.logOutUser()
    window.location.reload()
  }

}
