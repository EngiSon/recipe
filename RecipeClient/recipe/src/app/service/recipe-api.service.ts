import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Recipe } from '../model/Recipe';

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

}
