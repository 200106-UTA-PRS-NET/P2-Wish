import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';
import { userData, respData } from '../dataObj';
import { AlertService } from '../alert.service';

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
    private _http: HttpService,
    private alert: AlertService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
        name: ['', Validators.required],
        email: ['', Validators.required, Validators.email],
        username: ['', Validators.required],
        password: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

    get f() { return this.loginForm.controls; }

    onSubmit() {
      this.submitted = true;
      console.log(this.loginForm.value);
      if (this.loginForm.invalid) {
        return;
    }
    /*
        if(this.loginForm.value.name == "" || this.loginForm.value.username == "" || this.loginForm.value.password == "" || this.loginForm.value.email == "")
        {
          this.alert.error("7 characters minimum for username and password");
        }
        */
        this._http.registerAdd(this.loginForm.value).subscribe((check: boolean)=>
        {
          console.log(check);
          if(check == true)
          {
            console.log("success");
            this.router.navigate(['/login']);
            this.alert.success("account created");
          }
          else
          {
            console.log("invalid username or email");
            this.alert.warn("invalid username or email");
          }
        },
        error => {
          this.alert.warn("7 characters minimum for username and password");
        }
        );
     
        // reset alerts on submit
    
        // stop here if form is invalid
    
    }
}

