import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { HttpService } from '../http.service';
import { filterData } from '../filterObj';
import { gameData } from '../gamesObj';
import { Identifiers } from '@angular/compiler';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../alert.service';




interface Genre {
  value: string;
  viewValue: string;
}

interface Platform {
  value: string;
  viewValue: string;
}

interface Genre2 {
  id: number;
  name: string;
}

interface Platform2 {
  id: number;
  name: string;
}

interface Game{
  id: number;
  name: string;
  released: string;
  rating: number;
  platforms: Platform2[];
  genres: Genre2[];
  description: string;
  background_image: string;
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

  MediaID: number;
  counter: number;

  x: string;
  y: number;

  gmData: gameData;
  game: Game;


  genres: Genre[] = [
    {value: '4', viewValue: 'Action'},
    {value: '51', viewValue: 'Indie'},
    {value: '3', viewValue: 'Adventure'},
    {value: '5', viewValue: 'RPG'},
    {value: '2', viewValue: 'Shooter'},
    {value: '10', viewValue: 'Strategy'},
    {value: '40', viewValue: 'Casual'},
    {value: '14', viewValue: 'Simulation'},
    {value: '7', viewValue: 'Puzzle'},
    {value: '11', viewValue: 'Arcade'},
    {value: '83', viewValue: 'Platformer'},
    {value: '1', viewValue: 'Racing'},
    {value: '15', viewValue: 'Sports'},
    {value: '59', viewValue: 'Massively Multiplayer'},
    {value: '19', viewValue: 'Family'},
    {value: '6', viewValue: 'Fighting'},
    {value: '28', viewValue: 'Board Games'},
    {value: '34', viewValue: 'Educational'},
    {value: '17', viewValue: 'Card'}
  ];

  platformForm: FormGroup;
  platforms: Platform[] = [
    {value: '1', viewValue: 'Xbox One'},
    {value: '14', viewValue: 'Xbox 360'},
    {value: '18', viewValue: 'Playstation 4'},
    {value: '16', viewValue: 'Playstation 3'},
    {value: '15', viewValue: 'Playstation 2'},
    {value: '7', viewValue: 'Nintendo Switch'},
    {value: '8', viewValue: 'Nintendo 3Ds'},
    {value: '105', viewValue: 'GameCube'},
    {value: '83', viewValue: 'Nintendo 64'}
  ];



  constructor(private _http: HttpService,
    private router: Router,
    private alert: AlertService

    ) { }

  ngOnInit(): void {
    if (localStorage.getItem('loggedInUserID') == null ) {
      this.router.navigate(['/login']);
      this.alert.warn("Login first, ok");
    }
  }


  findGame(e: NgForm): void{
    this.games = null;
    console.log(e.value.Name);

    this.queryString = `/search/${e.value.Name}`;
    console.log(this.queryString);
    this._http.getGames(this.queryString).subscribe(
      data => {
      this.game = data as Game;
      console.log(this.game);
      },
      error => {
        this.alert.warn("Invalid search");
      }
  );
  
}


  getGame(f: NgForm, g: NgForm): void 
  {
    this.game = null;
    this.counter = 1;

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
        this.queryString = `/platform/${g.value.PlatformID}/${this.counter}`;
        console.log(this.queryString);
      }
      else
      {
        this.queryString = `/genre/${f.value.GenreID}/${this.counter}`;
        console.log(this.queryString);
      }
    }
    else
    {
      this.queryString = `/genre=${f.value.GenreID}&platform=${g.value.PlatformID}/${this.counter}`;
      console.log(this.queryString);
    }

    this._http.getGames(this.queryString).subscribe(data => {
      this.games = data;
      console.log(data);
      console.log(this.games);
    });
  }


  getGameF(f: NgForm, g: NgForm): void 
  {
    this.counter++;

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
        this.queryString = `/platform/${g.value.PlatformID}/${this.counter}`;
        console.log(this.queryString);
      }
      else
      {
        this.queryString = `/genre/${f.value.GenreID}/${this.counter}`;
        console.log(this.queryString);
      }
    }
    else
    {
      this.queryString = `/genre=${f.value.GenreID}&platform=${g.value.PlatformID}/${this.counter}`;
      console.log(this.queryString);
    }

    this._http.getGames(this.queryString).subscribe(data => {
      this.games = data;
      console.log(data);
      console.log(this.games);
    });
    
  }



  getGameR(f: NgForm, g: NgForm): void 
  {
    if(this.counter>1)
    {
      this.counter--;
    }

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
        this.queryString = `/platform/${g.value.PlatformID}/${this.counter}`;
        console.log(this.queryString);
      }
      else
      {
        this.queryString = `/genre/${f.value.GenreID}/${this.counter}`;
        console.log(this.queryString);
      }
    }
    else
    {
      this.queryString = `/genre=${f.value.GenreID}&platform=${g.value.PlatformID}/${this.counter}`;
      console.log(this.queryString);
    }

    this._http.getGames(this.queryString).subscribe(data => {
      this.games = data;
      console.log(data);
      console.log(this.games);
    });


    
  }

  submitGame(MediaID: number): void
  {
    console.log(MediaID);
    this.x = localStorage.getItem('loggedInUserID');
    console.log(this.x);
    this.y = +this.x;
    console.log(this.y);
  
    let objGame = {userID: this.y, mediaID: MediaID};
  
    console.log(objGame);
    
  
    
      this._http.addGame(objGame).subscribe((check : boolean)=>
      {
        console.log(check);
        if(check == true)
        {
          console.log("Game Added");
        }
        else
        {
          console.log("You already have this Game");
          this.alert.warn("You already have this Game");
        }
      },

      ); 
    
  }

}
