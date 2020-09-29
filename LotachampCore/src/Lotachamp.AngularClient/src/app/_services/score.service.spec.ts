import { TestBed } from '@angular/core/testing';

import { ScoreService } from './score.service';
import { HttpClientModule } from '@angular/common/http';

describe('ScoreService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [],
    imports: [HttpClientModule],
    providers: []
  }));

  it('should be created', () => {
    const service: ScoreService = TestBed.get(ScoreService);
    expect(service).toBeTruthy();
  });
});
