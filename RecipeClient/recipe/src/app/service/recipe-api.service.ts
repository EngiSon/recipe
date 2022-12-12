import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Recipe } from '../model/Recipe';
import { User } from '../model/User';

@Injectable({
  providedIn: 'root'
})
export class RecipeApiService {

  private readonly uri: string = "http://localhost:5159/api/"

  constructor(private http: HttpClient) { }

  public getAllRecipes(): Promise<Recipe[]>
  {
    return firstValueFrom(this.http.get<Recipe[]>(this.uri + "recipes"))
  }

  public getRecipe(id: number): Promise<Recipe>
  {
    return firstValueFrom(this.http.get<Recipe>(this.uri + "recipes/" + id))
  }

  public addNewRecipe(recipe: Recipe): Promise<any>
  {
    return firstValueFrom(this.http.post(this.uri + "recipes", recipe))
  }

  public deleteRecipe(id: number): Promise<any>
  {
    return firstValueFrom(this.http.delete(this.uri + "recipes/" + id))
  }

  public getUser(id: number): Promise<User>
  {
    return firstValueFrom(this.http.get<User>(this.uri + "users/" + id))
  }

}
