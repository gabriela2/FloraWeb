import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { ICategory } from '../shared/models/category';
import { IType } from '../shared/models/flowerType';
import { map, delay } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getFlowers(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.categoryId !== 0) {
      params = params.append('categoryId', shopParams.categoryId.toString());
    }

    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'flowers', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + 'flowers/categories');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'flowers/types');
  }
}