import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  queryString: string;
  list: Object;

  constructor(private _http: HttpService) { }

  ngOnInit(): void {
    this.queryString = `4`;
    //this.queryString = `/genre/14`;
    console.log(this.queryString);
    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;
      console.log(this.list);
    });

}
}
