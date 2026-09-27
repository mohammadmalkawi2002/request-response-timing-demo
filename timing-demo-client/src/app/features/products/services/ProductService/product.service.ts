import { HttpClient, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PagedResponse } from "../../models/paged-response.model";
import { CreateProductRequest, Product } from "../../models/products.models";
import { environment } from "../../../../../environments/environment";


@Injectable({
  providedIn: 'root'
})

export class ProductService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = `${environment.apiUrl}/Products`;

  getProducts(pageNumber: number = 1, pageSize: number = 10, categoryId?: number): Observable<PagedResponse<Product>> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize)

    if (categoryId != undefined) {
      params = params.set('categoryId', categoryId);
    }


    return this.http.get<PagedResponse<Product>>(this.apiUrl, { params });
  }

  getProductById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  createProduct(request: CreateProductRequest): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, request);

  }
}
