import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule }   from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { OptionsComponent } from './options/options.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { MoviesComponent } from './movies/movies.component';
import { MovielistComponent } from './movielist/movielist.component';
import { GamesComponent } from './games/games.component';
import { GamelistComponent } from './gamelist/gamelist.component';
import { PubliclistComponent } from './publiclist/publiclist.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    OptionsComponent,
    WishlistComponent,
    MoviesComponent,
    MovielistComponent,
    GamesComponent,
    GamelistComponent,
    PubliclistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }