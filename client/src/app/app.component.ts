import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IFlower } from './models/flower';
import {IPagination} from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FloraWeb';
  flowers : IFlower[];
  constructor(private http: HttpClient){}
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products?pageSize=50').subscribe((response: IPagination) => {
      this.flowers = response.data;
      console.log(this.flowers)
    }, error => {
      console.log(error);
    });
  }
}

