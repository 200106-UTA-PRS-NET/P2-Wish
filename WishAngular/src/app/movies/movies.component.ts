import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { HttpService } from '../http.service';
import { filterData } from '../filterObj';
import { gameData } from '../gamesObj';
import { addData } from '../addObj';
import { Identifiers } from '@angular/compiler';


interface Genre {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {


  genreForm: FormGroup;
  queryString: string;
  movies: Object;
  movies2: Object;
  movies3: Object;
  counter: number;
  counter2: number;

  x: string;
  y: number;

  addD: addData;


  genres: Genre[] = [
    {value: '28', viewValue: 'Action'},
    {value: '12', viewValue: 'Adventure'},
    {value: '16', viewValue: 'Animation'},
    {value: '35', viewValue: 'Comedy'},
    {value: '80', viewValue: 'Crime'},
    {value: '99', viewValue: 'Documentary'},
    {value: '18', viewValue: 'Drama'},
    {value: '10751', viewValue: 'Family'},
    {value: '14', viewValue: 'Fantasy'},
    {value: '36', viewValue: 'History'},
    {value: '27', viewValue: 'Horror'},
    {value: '10402', viewValue: 'Music'},
    {value: '9648', viewValue: 'Mystery'},
    {value: '10749', viewValue: 'Romance'},
    {value: '878', viewValue: 'Science Fiction'},
    {value: '10770', viewValue: 'TV Movie'},
    {value: '53', viewValue: 'Thriller'},
    {value: '10752', viewValue: 'War'},
    {value: '37', viewValue: 'Western'}
  ];

  constructor(private _http: HttpService) { }

  ngOnInit(): void {
  }


  findMovie(e: NgForm): void{
    console.log(e.value.Name);


    this.movies2 = null;
    this.movies = null;

    this.queryString = `/search/${e.value.Name}`;
    console.log(this.queryString);
    this._http.getMovies(this.queryString).subscribe(data => {
      this.movies3 = data;
      console.log(data);
      console.log(this.movies3);
  });
}


  getMovie(f: NgForm): void 
  {
    this.counter2 = 1;
    console.log(f.value);

    this.queryString = `/genre/${f.value.GenreID}/${this.counter2}`;
    console.log(this.queryString);
    this._http.getMovies(this.queryString).subscribe(data => {
      this.movies2 = data;
      console.log(data);
      console.log(this.movies);
    });
    
  }

  getMovieF(f: NgForm): void 
  {
    this.counter2++;
    console.log(f.value);

    this.queryString = `/genre/${f.value.GenreID}/${this.counter2}`;
    console.log(this.queryString);
    this._http.getMovies(this.queryString).subscribe(data => {
      this.movies2 = data;
      console.log(data);
      console.log(this.movies);
    });
    
  }

  getMovieP(f: NgForm): void 
  {
    if(this.counter2>1)
    {
      this.counter2--;
    }

    console.log(f.value);

    this.queryString = `/genre/${f.value.GenreID}/${this.counter2}`;
    console.log(this.queryString);
    this._http.getMovies(this.queryString).subscribe(data => {
      this.movies2 = data;
      console.log(data);
      console.log(this.movies);
    });
    
  }



  getPopular(): void
  {
    this.counter = 1;
    this.queryString = `/popular/${this.counter}`;
    console.log(this.queryString);
    this._http.getMovies(this.queryString).subscribe(data => {
      this.movies = data;
      console.log(this.movies);
  });
}

getPopularP(): void
{
  if(this.counter>1)
  {
    this.counter--;
  }
  console.log(this.counter);
  this.queryString = `/popular/${this.counter}`;
  console.log(this.queryString);
  this._http.getMovies(this.queryString).subscribe(data => {
    this.movies = data;
    console.log(this.movies);
});
}

getPopularF(): void
{
  this.counter++;
  console.log(this.counter);
  this.queryString = `/popular/${this.counter}`;
  console.log(this.queryString);
  this._http.getMovies(this.queryString).subscribe(data => {
    this.movies = data;
    console.log(this.movies);
});
}

submitGame(MediaID: number): void
{
  console.log(MediaID);
  this.x = localStorage.getItem('loggedInUserID');
  console.log(this.x);
  this.y = +this.x;
  console.log(this.y);

  /*
  this.addD.userID = this.y;
  this.addD.mediaID = MediaID;
  console.log(this.addD.userID);
  */

  /*
    this._http.checkUser(this.loginForm.value).subscribe((res : respData)=>
    {
      this.resData = res;
      console.log(this.resData);
      if(this.resData == null)

    });
    */
  
}


}
