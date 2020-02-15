import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';
import { userData, respData } from '../dataObj';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

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
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
        name: ['', Validators.required],
        email: ['', Validators.required, Validators.email],
        username: ['', Validators.required],
        password: ['', Validators.required]
    });
  }

    get f() { return this.loginForm.controls; }

    onSubmit() {
      console.log(this.loginForm.value);
      if (this.loginForm.invalid) {
        return;
      }
      /*
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
          this.router.navigate(['/options']);
        }
      });
  
  
      // reset alerts on submit
  
      // stop here if form is invalid
      if (this.loginForm.invalid) {
          return;
      }
      */
  
  }
}

