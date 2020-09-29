import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ToursComponent } from './tours.component';
import { TourDetailComponent } from '../tour-detail/tour-detail.component';
import { TourService } from 'src/app/_services/tour.service';
import { HttpClientModule } from '@angular/common/http';

describe('ToursComponent', () => {
  let component: ToursComponent;
  let fixture: ComponentFixture<ToursComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ToursComponent, TourDetailComponent],
      imports: [HttpClientModule],
      providers: [TourService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ToursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
