import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { userData, respData } from './dataObj';
import { filterData } from './filterObj';

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


}
