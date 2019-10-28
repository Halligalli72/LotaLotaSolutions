import { Component, OnInit, Input } from '@angular/core';
import { Tour } from 'src/app/models/tour.model';

@Component({
  selector: 'app-tour-detail',
  templateUrl: './tour-detail.component.html',
  styleUrls: ['./tour-detail.component.css']
})
export class TourDetailComponent implements OnInit {
  @Input() tour: Tour;

  constructor() { }

  ngOnInit() {
  }

}
