import { Injectable } from '@angular/core';
import { Item } from '../../types/item'
import { HttpClient, HttpParams } from '@angular/common/http';
import { Response } from '../../types/response';

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

  createItem(item: Item) {
    return this.http.post<Item>(this.API_URL + "?userStorageLocationId=3&stock=500", item, { params: HttpParams });
  }
}
