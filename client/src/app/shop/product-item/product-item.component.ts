import { Component, OnInit, Input } from '@angular/core';
import { IFlower } from 'src/app/shared/models/flower';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() flower: IFlower;

  constructor() { }

  ngOnInit() {
  }

}