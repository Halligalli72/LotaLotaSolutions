import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Score } from 'src/app/_models/score.model';
import { Participant } from 'src/app/_models/participant.model';
import { Sport } from 'src/app/_models/sport.model';
import { ParticipantService } from 'src/app/_services/participant.service';
import { SportService } from 'src/app/_services/sport.service';

@Component({
  selector: 'app-register-score',
  templateUrl: './register-score.component.html',
  styleUrls: ['./register-score.component.css']
})
export class RegisterScoreComponent implements OnInit {
  scoreForm: FormGroup;
  model: Score = new Score('', 1, '', '', 0, '', new Date(), 0, '', '', '', 0, 0);
  competitors: Participant[];
  sports: Sport[];
  submitted = false;

  constructor(private participantSvc: ParticipantService, private sportSvc: SportService) { }

  ngOnInit() {
    let tourId = 1;
    this.participantSvc.getByTour(tourId).subscribe((data: Participant[]) => {
      this.competitors = data;
    });
    this.sportSvc.getByTour(tourId).subscribe((data: Sport[]) => {
      this.sports = data;
    });
  }

  onSubmit() {
    alert('hej apa!');
    this.submitted = true;
  }

}
