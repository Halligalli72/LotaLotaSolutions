export class CreateScoreDto {
  constructor (
      tourId?: number,
      participantId?: string,
      sportId?: number,
      scoreDate?: Date,
      resultValue?: number,
      notes?: string,
      createdBy?: string
  ) {}
}
