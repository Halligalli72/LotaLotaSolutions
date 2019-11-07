import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Score } from '../_models/score.model';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number): Observable<Score> {
    let url = environment.apiRootUrl + '/api/Score/GetByTour/' + tourId;
    return this.http.get(url);
  }

}
