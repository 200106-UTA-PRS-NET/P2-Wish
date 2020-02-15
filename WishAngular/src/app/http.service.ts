import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { userData, respData } from './dataObj';
import { filterData } from './filterObj';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  url='http://mediawish.azurewebsites.net/movies/popular/1';

  constructor(private http: HttpClient) { }


  getMovies()
  {
    //return this.http.get('https://api.themoviedb.org/3/movie/122?api_key=9e5b0ab89fd681ae90099669cd36adc8&language=en-US')
    return this.http.get(this.url)
  }

  checkUser (userD: userData)
  {
    return this.http.post('http://mediawish.azurewebsites.net/users/login', userD);
  }

  getGames(filterD: string)
  {
    return this.http.get('http://mediawish.azurewebsites.net/games'+filterD);
  }



}
