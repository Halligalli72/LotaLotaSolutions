import { Component, OnInit } from '@angular/core';
import { TourService } from 'src/app/_services/tour.service';
import { Tour } from 'src/app/_models/tour.model';

@Component({
  selector: 'app-tour-list',
  templateUrl: './tour-list.component.html',
  styleUrls: ['./tour-list.component.css']
})
export class TourListComponent implements OnInit {

  constructor(private tourSvc: TourService) { }
    tours: Tour[];
  ngOnInit() {
    this.tourSvc.getOngoing()
    .subscribe(
      (data: Tour[]) => {
       console.log('OK!');
       this.tours = data;
    }, (error: any) => {
      console.error('Error: ', error);
    });

  }

}
