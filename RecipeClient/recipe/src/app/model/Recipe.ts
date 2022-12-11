import { FoodType } from "./FoodType"

export class Recipe
{
  public id: number
  public userId: number
  public name: string
  public foodType: FoodType
  public ingredients: string
  public description: string

  constructor(id: number, userId: number, name: string, foodType: number, ingredients: string, description: string)
  {
    this.id = id
    this.userId = userId
    this.name = name
    this.foodType = foodType,
    this.ingredients = ingredients,
    this.description = description
  }
}
