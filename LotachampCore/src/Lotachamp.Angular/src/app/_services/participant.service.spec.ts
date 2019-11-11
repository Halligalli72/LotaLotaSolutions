import { TestBed } from '@angular/core/testing';

import { ParticipantService } from './participant.service';
import { HttpClientModule } from '@angular/common/http';

describe('ParticipantService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [],
    imports: [HttpClientModule],
    providers: []
  }));

  it('should be created', () => {
    const service: ParticipantService = TestBed.get(ParticipantService);
    expect(service).toBeTruthy();
  });
});
