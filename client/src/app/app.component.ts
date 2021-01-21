import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IFlower } from './shared/Models/flower';
import {IPagination} from './shared/Models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FloraWeb';


  constructor(private http: HttpClient){}
  
  ngOnInit(): void {
  }
}

