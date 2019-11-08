import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Sport } from '../_models/sport.model';

@Injectable({
  providedIn: 'root'
})
export class SportService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number): Observable<Sport> {
    let url = environment.apiRootUrl + '/api/Sport/GetByTour/' + tourId;
    return this.http.get(url);
  }

}
