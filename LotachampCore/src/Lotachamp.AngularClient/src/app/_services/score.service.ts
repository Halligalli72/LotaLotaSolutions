import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Score } from '../_models/score.model';
import { CreateScoreDto } from '../_models/create-score-dto.model';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number): Observable<Score> {
    let url = environment.apiRootUrl + '/api/Score/GetByTour/' + tourId;
    return this.http.get(url);
  }

  createScore(data: CreateScoreDto) {
    let url = environment.apiRootUrl + '/api/Score/Create';
    return this.http.post<CreateScoreDto>(url, data);
  }

}
