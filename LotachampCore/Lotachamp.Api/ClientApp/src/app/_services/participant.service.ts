import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Participant } from '../_models/participant.model';

@Injectable({
  providedIn: 'root'
})
export class ParticipantService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number): Observable<Participant> {
    let url = environment.apiRootUrl + '/api/Participant/GetByTour/' + tourId;
    return this.http.get(url);
  }
}
