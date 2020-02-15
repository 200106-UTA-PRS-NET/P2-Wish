import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { OptionsComponent } from './options/options.component';
import { RegisterComponent } from './register/register.component';
import { GamesComponent } from './games/games.component';
import { MoviesComponent } from './movies/movies.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { GamelistComponent } from './gamelist/gamelist.component';
import { MovielistComponent } from './movielist/movielist.component';


const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'options', component: OptionsComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'games', component: GamesComponent},
  {path: 'movies', component: MoviesComponent},
  {path: 'wishlist', component: WishlistComponent},
  {path: 'gamelist', component: GamelistComponent},
  {path: 'movielist', component: MovielistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
