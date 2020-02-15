import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { HttpService } from '../http.service';
import { filterData } from '../filterObj';
import { gameData } from '../gamesObj';
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
  counter: number;
  counter2: number;


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

  getMovieDetail(id: number) {
    console.log(id);
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


}
