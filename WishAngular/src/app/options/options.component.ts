import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../alert.service';

@Component({
  selector: 'app-options',
  templateUrl: './options.component.html',
  styleUrls: ['./options.component.css']
})
export class OptionsComponent implements OnInit {

  movies: Object;

  constructor(private _http: HttpService,
    private router: Router,
    private alert: AlertService
    ) { }

  ngOnInit(): void {
    this.alert.clear();
    if (localStorage.getItem('loggedInUserID') == null ) {
      this.router.navigate(['/login']);
    }
  }


    signOut() {
      localStorage.clear();
      window.location.reload();
      this.router.navigate(['/login']);
    }
}

