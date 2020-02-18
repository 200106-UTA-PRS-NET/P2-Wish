import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from './http.service';
import { userData, respData, publicData } from './dataObj';
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
  pData : publicData;


  constructor(
    private _http: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    ) { }

  findUserList(e: NgForm): void{
    this.queryString = e.value.Name;
    console.log(e.value.Name);
    this._http.checkUserId(this.queryString).subscribe((p : publicData)=>
    {
      this.pData = p;
      console.log(this.pData);
      if(this.pData == null)
      {
        console.log("Not a valid ID");
      }
      else
      {
        localStorage.setItem('publicUserID', this.pData.id);
        localStorage.setItem('publicUserName', this.pData.name);
        this.router.navigate(['/publiclist']);
      }
    });

  }

}
