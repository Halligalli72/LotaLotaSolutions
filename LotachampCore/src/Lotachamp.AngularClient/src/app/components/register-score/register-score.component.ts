import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Participant } from 'src/app/_models/participant.model';
import { Sport } from 'src/app/_models/sport.model';
import { ParticipantService } from 'src/app/_services/participant.service';
import { SportService } from 'src/app/_services/sport.service';
import { ScoreService } from 'src/app/_services/score.service';
import { CreateScoreDto } from 'src/app/_models/create-score-dto.model';
import { TourService } from 'src/app/_services/tour.service';
import { Tour } from 'src/app/_models/tour.model';

@Component({
  selector: 'app-register-score',
  templateUrl: './register-score.component.html',
  styleUrls: ['./register-score.component.css']
})
export class RegisterScoreComponent implements OnInit {
  scoreForm: FormGroup;
  model: CreateScoreDto;
  tours: Tour[];
  competitors: Participant[];
  sports: Sport[];
  submitted = false;

  constructor(private tourSvc: TourService,
              private participantSvc: ParticipantService,
              private sportSvc: SportService,
              private scoreSvc: ScoreService) { }

  ngOnInit() {
    let tourId = 1;
    this.tourSvc.getOngoing().subscribe((data: Tour[]) => {
      this.tours = data;
    });
    this.participantSvc.getByTour(tourId).subscribe((data: Participant[]) => {
      this.competitors = data;
    });
    this.sportSvc.getByTour(tourId).subscribe((data: Sport[]) => {
      this.sports = data;
    });
    this.model = new CreateScoreDto(tourId, '', 0, new Date(), 0, '', 'admin');
  }

  onSubmit() {
    this.submitted = true;
    this.saveScore(this.model);
  }

  saveScore(data: CreateScoreDto) {
    this.scoreSvc.createScore(data)
      .subscribe(
        (resp: any) => {
          // Allt OK
          // console.log('JSON response received: ' + JSON.stringify(resp));
          console.log('Score saved.');
        },
        (res: any) => {
          // Error - något gick fel
          this.submitted = false;
          console.error('Ospecificerat fel: ' + res.message);
        }
      );
  }
}
