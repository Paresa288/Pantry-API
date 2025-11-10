import { Injectable } from '@angular/core';
import { Item } from '../../types/item'
import { HttpClient } from '@angular/common/http';
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
    return this.http.get<Response>(this.API_URL);
  }
}
