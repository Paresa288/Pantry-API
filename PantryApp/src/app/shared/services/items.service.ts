import { Injectable } from '@angular/core';
import { Item } from '../../types/item'
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class ItemsServiceService {
  readonly API_URL = "https://localhost:7157/api/Items"
  
  items: Item[];
  
  constructor(private http: HttpClient) {
    this.items = [];
  }

  getItems() {
    return this.http.get<Item[]>(this.API_URL);
  }

  createItem(item: Item, USLId: number, stock: number) {
    return this.http.post<Item>(this.API_URL, item, { params: new HttpParams().set('userStorageLocationId', USLId).set('stock', stock) });
  }

  deleteItem(itemId: number) {
    return this.http.delete(`${this.API_URL}/${itemId}`);
  }
}
