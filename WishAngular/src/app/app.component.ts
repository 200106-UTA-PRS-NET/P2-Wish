import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from './http.service';
import { userData, respData } from './dataObj';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  loginForm: FormGroup;
  title = 'WishAngular';
  queryString: string;
  list: Object;


  constructor(
    private _http: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    ) { }

  findUserList(e: NgForm): void{
    this.router.navigate(['/']);

    console.log(e.value.Name);

    this.queryString = e.value.Name;
    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;
      console.log(this.list);
    });

  }

}
