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
  }

    get f() { return this.loginForm.controls; }

    onSubmit() {
      console.log(this.loginForm.value);


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
        });
    
    
        // reset alerts on submit
    
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
    
    }
}

