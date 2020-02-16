import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router, ActivatedRoute } from '@angular/router';

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

  constructor(
    private _http: HttpService,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit(): void {
    this.queryString = localStorage.getItem('loggedInUserID');
    console.log(this.queryString);
    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;
      console.log(this.list);
    });

    console.log(localStorage.getItem('loggedInUserID'));
    console.log(sessionStorage.getItem('loggedInUserID'));
    console.log(localStorage.getItem('loggedInName'));
    console.log(sessionStorage.getItem('loggedInName'));   

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
