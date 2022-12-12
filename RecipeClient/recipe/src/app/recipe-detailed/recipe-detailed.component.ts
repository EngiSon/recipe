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

  recipe: Recipe | undefined
  author: User | undefined

  constructor(
    private route: ActivatedRoute,
    private apiSvc: RecipeApiService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.getRecipe()
    this.getUser()
  }

  getRecipe(): void
  {
    const id = parseInt(this.route.snapshot.paramMap.get('id'))
    this.apiSvc.getRecipe(id).then(recipe => this.recipe = recipe)
  }

  getUser(): void
  {
    this.apiSvc.getUser(this.recipe.userId).then(user => this.author = user)
  }

  goBack(): void
  {
    this.location.back();
  }

  deleteRecipe()
  {
    this.apiSvc.deleteRecipe(this.recipe.id)
  }
}
