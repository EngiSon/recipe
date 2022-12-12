import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecipeApiService } from './service/recipe-api.service';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { RecipeDetailedComponent } from './recipe-detailed/recipe-detailed.component';
import { RecipeAddComponent } from './recipe-add/recipe-add.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    RecipeListComponent,
    RecipeDetailedComponent,
    RecipeAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    RecipeApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
