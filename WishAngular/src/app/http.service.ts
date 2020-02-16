import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { userData, respData, regData } from './dataObj';
import { idData } from './deleteObj';
import { filterData } from './filterObj';
import { addData } from './addObj';

@Injectable({
  providedIn: 'root'
})
export class HttpService {


  constructor(private http: HttpClient) { }


  getMovies(filterM: string)
  {
    return this.http.get('http://mediawish.azurewebsites.net/movies'+filterM);
  }

  checkUser (userD: userData)
  {
    return this.http.post('http://mediawish.azurewebsites.net/users/login', userD);
  }

  getGames(filterD: string)
  {
    return this.http.get('http://mediawish.azurewebsites.net/games'+filterD);
  }

  getList(filterId: string)
  {
    return this.http.get('http://mediawish.azurewebsites.net/wishlists/viewall/'+filterId);
  }

  
  deleteList(id: string)
  {
    return this.http.delete('http://mediawish.azurewebsites.net/wishlists/remove'+id);
  }
  

  addGame(add: addData)
  {
    return this.http.post('http://mediawish.azurewebsites.net/wishlists/game/add', add);
  }

  addMovie(add: addData)
  {
    return this.http.post('http://mediawish.azurewebsites.net/wishlists/movie/add', add);
  }

  registerAdd(add: regData)
  {
    return this.http.post('http://mediawish.azurewebsites.net/users/create', add);
  }


}
