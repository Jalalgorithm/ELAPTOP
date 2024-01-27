import { Pagination } from '../shared/models/pagination';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:7252/api/';

  constructor(private http: HttpClient) {}

  getProduct() {
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'products');
  }
}
