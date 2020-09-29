import { TestBed } from '@angular/core/testing';

import { TourService } from './tour.service';
import { HttpClientModule } from '@angular/common/http';

describe('TourService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [],
    imports: [HttpClientModule],
    providers: []
  }));

  it('should be created', () => {
    const service: TourService = TestBed.get(TourService);
    expect(service).toBeTruthy();
  });
});
