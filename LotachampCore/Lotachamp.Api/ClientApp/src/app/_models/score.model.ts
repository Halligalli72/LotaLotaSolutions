export class Score {
  constructor(
    public scoreId?: string,
    public tourId?: number,
    public participant?: string,
    public sportEvent?: string,
    public scoreDate?: Date,
    public resultValue?: number,
    public resultUnit?: string,
    public imageUrl?: string,
    public notes?: string,
    public points?: number,
    public rank?: number,
    public created?: Date,
    public createdBy?: string,
    public updated?: Date,
    public updatedBy?: string,
  ) { }
}
