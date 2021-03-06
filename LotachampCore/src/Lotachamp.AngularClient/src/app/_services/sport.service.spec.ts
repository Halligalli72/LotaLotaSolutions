import { TestBed } from '@angular/core/testing';

import { SportService } from './sport.service';
import { HttpClientModule } from '@angular/common/http';

describe('SportService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [],
    imports: [HttpClientModule],
    providers: []
  }));

  it('should be created', () => {
    const service: SportService = TestBed.get(SportService);
    expect(service).toBeTruthy();
  });
});
