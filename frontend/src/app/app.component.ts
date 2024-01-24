import { Pagination } from './models/pagination';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Eudev';
  products: Product[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http
      .get<Pagination<Product[]>>('https://localhost:7252/api/products')
      .subscribe({
        next: (response: any) => (this.products = response.data),
        error: (error) => console.log(error),
        complete: () => {
          console.log('request completed');
          console.log('extra statement');
        },
      });
  }
}
