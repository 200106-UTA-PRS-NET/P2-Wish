import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';
import { userData, respData } from '../dataObj';


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

data: string;
useData: userData;
resData: respData;


constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _http: HttpService
) {
    // redirect to home if already logged in
}

ngOnInit() {
    this.loginForm = this.formBuilder.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
}

// convenience getter for easy access to form fields
get f() { return this.loginForm.controls; }

onSubmit() {
    this.submitted = true;
    this._http.checkUser(this.loginForm.value).subscribe((res : respData)=>
    {
      this.resData = res;
      console.log(this.resData);
      if(this.resData == null)
      {
        console.log("invalid username or password");
      }
      else
      {
        localStorage.setItem('loggedInUserID', this.resData.id);
        sessionStorage.setItem('loggedInUserID', this.resData.id);
        localStorage.setItem('loggedInName', this.resData.name);
        sessionStorage.setItem('loggedInName', this.resData.name);
        this.router.navigate(['/options']);
      }
    });


    // reset alerts on submit

    // stop here if form is invalid
    if (this.loginForm.invalid) {
        return;
    }

}
}
