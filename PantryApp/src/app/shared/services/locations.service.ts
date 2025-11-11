import { Injectable } from '@angular/core';
import { Location } from '../../types/location';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LocationsService {
  readonly API_URL = "https://localhost:7157/api/Locations";

  locations: Location[];

  constructor(private http : HttpClient) { 
    this.locations = [];
  }

  getLocations() {
    return this.http.get<Location[]>(this.API_URL);
  }
}
