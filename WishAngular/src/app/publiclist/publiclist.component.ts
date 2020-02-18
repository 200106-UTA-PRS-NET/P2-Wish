import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-publiclist',
  templateUrl: './publiclist.component.html',
  styleUrls: ['./publiclist.component.css']
})
export class PubliclistComponent implements OnInit {
  queryString: string;
  list: Object;


  name: string;

  constructor(private _http: HttpService) { }

  ngOnInit(): void {
    this.queryString = localStorage.getItem('publicUserID');
    this.name = localStorage.getItem('publicUserName');
    this._http.getList(this.queryString).subscribe(data => {
      this.list = data;

      if(this.list == null)
      {
        console.log("empty list");
      }
      else
      {
        console.log(this.list);
      }
    });

  }

}
