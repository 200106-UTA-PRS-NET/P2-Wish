import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { HttpService } from '../http.service';
import { filterData } from '../filterObj';




interface Genre {
  value: string;
  viewValue: string;
}

interface Platform {
  value: string;
  viewValue: string;
}

interface GameItem {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  genreForm: FormGroup;
  queryString: string;
  games: Object;






  genres: Genre[] = [
    {value: '4', viewValue: 'Action'},
    {value: '51', viewValue: 'Indie'},
    {value: '3', viewValue: 'Adventure'}
  ];

  platformForm: FormGroup;
  platforms: Platform[] = [
    {value: '1', viewValue: 'Xbox One'},
    {value: '18', viewValue: 'Playstation 4'},
    {value: '4', viewValue: 'PC'}
  ];



  constructor(private _http: HttpService) { }

  ngOnInit(): void {
  }


  findGame(e: NgForm): void{
    console.log(e.value);
    console.log(e.valid);
  }


  getGame(f: NgForm, g: NgForm): void 
  {

    console.log(f.value);
    console.log(g.value);

    if(f.value.GenreID == "" && g.value.PlatformID == "")
    {
      console.log("Must enter a value");
    }
    else if(f.value.GenreID == "" || g.value.PlatformID == "")
    {
      if(f.value.GenreID == "")
      {
        this.queryString = `/platform/${g.value.PlatformID}`;
        console.log(this.queryString);
      }
      else
      {
        this.queryString = `/genre/${f.value.GenreID}`;
        console.log(this.queryString);
      }
    }
    else
    {
      this.queryString = `/genre=${f.value.GenreID}&platform=${g.value.PlatformID}`;
      console.log(this.queryString);
    }

    this._http.getGames(this.queryString).subscribe(data => {
      this.games = data;
      console.log(data);
      console.log(this.games);
    });


    
  }

  submitGame()
  {

  }

}
