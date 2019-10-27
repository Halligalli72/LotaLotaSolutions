import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { strict } from 'assert';
import { environment } from 'src/environments/environment';
import { Participant } from '../models/participant.model';




@Injectable({
  providedIn: 'root'
})
export class ParticipantService {

  constructor(private http: HttpClient) { }

  getByTour(tourId: number) {
    let url = environment.apiRootUrl + '/api/Participant/GetByTour/' + tourId;
    return this.http.get(url);
  }
}
