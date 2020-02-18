import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from './http.service';
import { userData, respData, publicData } from './dataObj';
import { NgForm } from '@angular/forms';
import { AlertService } from './alert.service';
import { AlertComponent } from './alert/alert.component';
import { DataServiceService } from "./data-service.service";

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


  message:string;


  constructor(
    private _http: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    private alert: AlertService,
    private data: DataServiceService
    ) { }

    ngOnInit() {
      this.data.currentMessage.subscribe(message => this.message = message)
    }

  findUserList(e: NgForm): void{
    this.queryString = e.value.Name;
    console.log(e.value.Name);

    this._http.checkUserId(this.queryString).subscribe((p : publicData)=>
    {
      this.pData = p;
      console.log(this.pData);
      if(this.pData.email == null)
      {
        this.alert.error("Not a valid ID");
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
