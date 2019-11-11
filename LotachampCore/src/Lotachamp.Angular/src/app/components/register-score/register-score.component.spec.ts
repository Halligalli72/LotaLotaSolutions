import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterScoreComponent } from './register-score.component';
import { FormBuilder, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

describe('RegisterScoreComponent', () => {
  let component: RegisterScoreComponent;
  let fixture: ComponentFixture<RegisterScoreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, FormsModule, HttpClientModule],
      declarations: [ RegisterScoreComponent ],
      providers: [FormBuilder ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterScoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
