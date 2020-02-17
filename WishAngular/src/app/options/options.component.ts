import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.css']
})
export class OptionsComponent implements OnInit {

  movies: Object;

  constructor(private _http: HttpService,
    private router: Router,
    ) { }

  ngOnInit(): void {
    if (localStorage.getItem('loggedInUserID') == null ) {
      this.router.navigate(['/login']);
    }
  }


    signOut() {
      localStorage.clear();
      this.router.navigate(['/login']);
    }
}

