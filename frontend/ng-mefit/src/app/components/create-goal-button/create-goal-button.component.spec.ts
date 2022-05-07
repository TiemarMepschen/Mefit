import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGoalButtonComponent } from './create-goal-button.component';

describe('CreateGoalButtonComponent', () => {
  let component: CreateGoalButtonComponent;
  let fixture: ComponentFixture<CreateGoalButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateGoalButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGoalButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
