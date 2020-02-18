import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';
import { userData, respData } from '../dataObj';
import { AlertService } from '../alert.service';
import { DataServiceService } from "../data-service.service";



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

loginForm: FormGroup;
loading = false;
submitted = false;
returnUrl: string;

//data: string;
useData: userData;
resData: respData;

name: string;
id: number;

message: string;
setMessage: string;


constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _http: HttpService,
    private alert: AlertService,
    private data: DataServiceService
) {
    // redirect to home if already logged in
}

ngOnInit() {
  localStorage.clear();
    this.loginForm = this.formBuilder.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
    });
    this.data.currentMessage.subscribe(message => this.message = message)
    this.data.changeMessage('');

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
}

// convenience getter for easy access to form fields
get f() { return this.loginForm.controls; }

onSubmit() {
    this.submitted = true;

    if (this.loginForm.invalid) {
      return;
  }
    this._http.checkUser(this.loginForm.value).subscribe((res : respData)=>
    {
      this.resData = res;
      console.log(this.resData);
      if(this.resData == null)
      {
        console.log("invalid username or password");
        this.alert.warn("invalid username or password");

      }
      else
      {
        localStorage.setItem('loggedInUserID', this.resData.id);
        localStorage.setItem('loggedInName', this.resData.name);
        this.setMessage = `${this.resData.name}    ID:${this.resData.id}`
        this.data.changeMessage(this.setMessage);
        this.router.navigate(['/options']);
      }
    });


    // reset alerts on submit


}
}
