import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DataServiceService } from "../data-service.service";

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
    private data: DataServiceService) { }

  ngOnInit(): void {
    if (localStorage.getItem('loggedInUserID') == null ) {
      this.router.navigate(['/login']);
    }
    this.queryString = localStorage.getItem('loggedInUserID');
    this.name = localStorage.getItem('loggedInName');
    this.setMessage = `${this.name}    ID:${this.queryString}`
    this.data.changeMessage(this.setMessage);
    console.log(this.queryString);
    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;
      console.log(this.list);
    });  
    this.data.currentMessage.subscribe(message => this.message = message);

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
