import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../alert.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  queryString: string;
  list: Object;
  x: string;
  y: number;

  name: string;

  message: string;
  setMessage: string;

  constructor(
    private _http: HttpService,
    private route: ActivatedRoute,
    private router: Router,
    private alert: AlertService
    ) { }

  ngOnInit(): void {
    if (localStorage.getItem('loggedInUserID') == null ) {
      this.router.navigate(['/login']);
      this.alert.warn("Login first, ok");

    }
    this.queryString = localStorage.getItem('loggedInUserID');
    this.name = localStorage.getItem('loggedInName');


    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;
      console.log(this.list);
    });  

}
deleteItem(id: number): void
{

  console.log(id);
  this.x = `/${id}`;
  
    this._http.deleteList(this.x).subscribe((check : boolean)=>
    {
      console.log(check);
      if(check == true)
      {
        console.log("Item Deleted");
        window.location.reload();
      }
      else
      {
        console.log("How?");
      }


    }); 
  
}

}
