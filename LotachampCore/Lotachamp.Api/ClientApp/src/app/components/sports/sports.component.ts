import { Component, OnInit } from '@angular/core';
import { SportService } from 'src/app/_services/sport.service';
import { Sport } from 'src/app/_models/sport.model';

@Component({
  selector: 'app-sports',
  templateUrl: './sports.component.html',
  styleUrls: ['./sports.component.css']
})
export class SportsComponent implements OnInit {
  private sports: Sport[];

  constructor(private sportSvc: SportService) { }

  ngOnInit() {
    this.sportSvc.getByTour(1)
    .subscribe(
      (data: Sport[]) => {
       this.sports = data;
    }, (error: any) => {
      console.error('Error: ', error);
    });
  }

}
