import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SportService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number) {
    let url = environment.apiRootUrl + '/api/Sport/GetByTour/' + tourId;
    return this.http.get(url);
  }

}
