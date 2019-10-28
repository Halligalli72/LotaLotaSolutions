import { Component, OnInit } from '@angular/core';
import { TourService } from 'src/app/_services/tour.service';
import { Tour } from 'src/app/_models/tour.model';

@Component({
  selector: 'app-tours',
  templateUrl: './tours.component.html',
  styleUrls: ['./tours.component.css']
})
export class ToursComponent implements OnInit {

  constructor(private tourSvc: TourService) { }
    tours: Tour[];
    selectedTour: Tour;

  ngOnInit() {
    this.tourSvc.getOngoing()
    .subscribe(
      (data: Tour[]) => {
       this.tours = data;
    }, (error: any) => {
      console.error('Error: ', error);
    });
  }

  onSelect(tour: Tour) {
    if (this.selectedTour === tour){
      this.selectedTour = null;
    } else {
      this.selectedTour = tour;
    }
  }
}
