import { Participant } from "./participant.model";
import { SportEvent } from "./sport-event.model";
import { Tour } from "./tour.model";

export class Score {
  constructor(
    public scoreId?: number,
    public tour?: Tour,
    public participant?: Participant,
    public sportEvent?: SportEvent,
    public scoreDate?: Date,
    public resultValue?: number,
    public resultUnit?: string,
    public notes?: string,
    public points?: number,
    public rank?: number,
    public created?: Date,
    public createdBy?: string,
  ) { }
}
