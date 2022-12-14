import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from '../model/Recipe';
import { RecipeApiService } from '../service/recipe-api.service';
import { Location } from '@angular/common';
import { User } from '../model/User';

@Component({
  selector: 'rec-recipe-detailed',
  templateUrl: './recipe-detailed.component.html',
  styleUrls: ['./recipe-detailed.component.scss']
})
export class RecipeDetailedComponent implements OnInit {

  recipe: Recipe
  author: User
  currentUser : number
  dataLoaded: boolean = false;
  sameUser : boolean;

  constructor(
    private route: ActivatedRoute,
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  async ngOnInit(): Promise<void>
  {
    await this.getRecipe();
    this.getUser();
  }

  async getRecipe(): Promise<void>
  {
    const id = parseInt(this.route.snapshot.paramMap.get('id'))

    await this.apiSvc.getRecipe(id).then(result => this.recipe = result)
  }

  async getUser(): Promise<void>
  {
    await this.apiSvc.getUser(this.recipe.userId).then(result => this.author = result)
    this.currentUser = this.apiSvc.getLoggedInUserId()
    this.sameUser = (this.currentUser == this.recipe.userId);
    this.dataLoaded = true
  }

  goBack(): void
  {
    this.location.back();
  }

  async doFav(): Promise<void>
  {
    let noError = true
    await this.apiSvc.handleFavorite(this.currentUser,this.recipe.userId).catch( () =>
    {
      alert("User already favorited")
      noError = false
    });
    if (noError)
    {
      alert("User favorited succesfully!")
    }
  }

  deleteRecipe(): void
  {
    if (this.sameUser)
    {
      this.apiSvc.deleteRecipe(this.recipe.id)
      this.goBack();
    }
  }
}
