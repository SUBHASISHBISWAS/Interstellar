import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayExpensesComponent } from './display-expenses.component';

describe('DisplayExpensesComponent', () => {
  let component: DisplayExpensesComponent;
  let fixture: ComponentFixture<DisplayExpensesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayExpensesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayExpensesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
