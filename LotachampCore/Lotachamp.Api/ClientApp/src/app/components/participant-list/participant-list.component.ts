import { Component, OnInit } from '@angular/core';
import { Participant } from 'src/app/_models/participant.model';
import { ParticipantService } from 'src/app/_services/participant.service';

@Component({
  selector: 'app-participant-list',
  templateUrl: './participant-list.component.html',
  styleUrls: ['./participant-list.component.css']
})
export class ParticipantListComponent implements OnInit {
    private participants: Participant[];

  constructor(private participantSvc: ParticipantService) { }

  ngOnInit() {
    this.participantSvc.getByTour(1)
    .subscribe(
      (data: Participant[]) => {
       this.participants = data;
    },
    (error: any) => {
      console.error('Error: ', error);
    });
  }

}
