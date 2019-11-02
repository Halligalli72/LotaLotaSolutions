import { Component, OnInit } from '@angular/core';
import { Score } from 'src/app/_models/score.model';
import { ScoreService } from 'src/app/_services/score.service';

@Component({
  selector: 'app-scores',
  templateUrl: './scores.component.html',
  styleUrls: ['./scores.component.css']
})
export class ScoresComponent implements OnInit {
  private scores: Score[];

  constructor(private scoreSvc: ScoreService) { }

  ngOnInit() {
    this.scoreSvc.getByTour(1)
    .subscribe(
      (data: Score[]) => {
       this.scores = data;
    }, (error: any) => {
      console.error('Error: ', error);
    });
  }

}
