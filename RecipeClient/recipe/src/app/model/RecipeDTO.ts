import { FoodType } from "./FoodType"

class RecipeDTO
{
  public id: number
  public userId: number
  public name: string
  public foodType: string
  public ingredients: string
  public description: string

  constructor(id: number, userId: number, name: string, foodType: FoodType, ingredients: string, description: string)
  {
    this.id = id
    this.userId = userId
    this.name = name
    this.foodType = foodType.toString()
    this.ingredients = ingredients
    this.description = description
  }
}
