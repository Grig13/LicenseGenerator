import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { RouteConfigLoadEnd } from "@angular/router";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Product } from "../models/product";


@Injectable({
    providedIn: "root"
})
export class ProductService{

    private url = "Product";

    constructor(private http: HttpClient) {}

    public getProducts(): Observable<Product[]> {
        return this.http.get<Product[]>(`${environment.apiUrl}/${this.url}`)
    }
    public createProduct(product: Product) : Observable<Product[]> {
        return this.http.post<Product[]>(`${environment.apiUrl}/${this.url}`, product);
    }
    public deleteProduct(product : Product): Observable<Product[]>{
        return this.http.delete<Product[]>(`${environment.apiUrl}/${this.url}/${product.id}`)
      }
}