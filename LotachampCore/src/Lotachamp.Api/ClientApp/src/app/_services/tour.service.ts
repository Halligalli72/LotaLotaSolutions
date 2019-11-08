import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TourService {

  constructor(private http: HttpClient) { }

  get(tourId: number) {
    let url = environment.apiRootUrl + '/api/Tour/Get/' + tourId;
    return this.http.get(url);
  }

  getPassed() {
    let url = environment.apiRootUrl + '/api/Tour/GetPassed';
    return this.http.get(url);
  }

  getOngoing() {
    let url = environment.apiRootUrl + '/api/Tour/GetOngoing';
    return this.http.get(url);
  }

  getFuture() {
    let url = environment.apiRootUrl + '/api/Tour/GetFuture';
    return this.http.get(url);
  }
}
