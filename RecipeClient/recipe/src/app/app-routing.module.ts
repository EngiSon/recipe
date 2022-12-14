import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RecipeAddComponent } from './recipe-add/recipe-add.component';
import { RecipeDetailedComponent } from './recipe-detailed/recipe-detailed.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'home',
    component: RecipeListComponent
  },
  {
    path: 'recipes/:id',
    component: RecipeDetailedComponent
  },
  {
    path: 'recipe/add',
    component: RecipeAddComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
