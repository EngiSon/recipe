import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Recipe } from '../model/Recipe';
import { User } from '../model/User';
import { ValidationDTO } from '../model/ValidationDTO';

@Injectable({
  providedIn: 'root'
})
export class RecipeApiService {

  private loggedInUserId: number = 0

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

  public addNewUser(user: User): Promise<any>
  {
    return firstValueFrom(this.http.post(this.uri + "users", user))
  }

  public validateUser(loginfo: ValidationDTO): Promise<User>
  {
    return firstValueFrom(this.http.post<User>(this.uri + "users/validate", loginfo))
  }

  public logInUser(userId: number)
  {
    this.loggedInUserId = userId
    return userId
  }

  public logOutUser()
  {
    this.loggedInUserId = null
    return true
  }

  public getLoggedInUserId()
  {
    return this.loggedInUserId
  }

}
