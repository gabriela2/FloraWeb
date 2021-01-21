import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IFlower } from '../shared/models/flower';
import { ShopService } from './shop.service';
import { ICategory } from '../shared/models/category';
import { IType } from '../shared/models/flowerType';
import {ShopParams} from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  flowers: IFlower[];
  categories: ICategory[];
  types: IType[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit() {
    this.getFlowers();
    this.getCategories();
    this.getTypes();
  }

  getFlowers() {
    this.shopService.getFlowers(this.shopParams).subscribe(response => {
      this.flowers = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getCategories() {
    this.shopService.getCategories().subscribe(response => {
      this.categories = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.shopService.getTypes().subscribe(response => {
      this.types = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onCategorySelected(brandId: number) {
    this.shopParams.categoryId = brandId;
    this.shopParams.pageNumber = 1;
    this.getFlowers();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getFlowers();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getFlowers();
  }

  onPageChanged(event: any) {
    this.shopParams.pageNumber = event;
    if (this.shopParams.pageNumber === event) {
      this.getFlowers();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getFlowers();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getFlowers();
  }

}