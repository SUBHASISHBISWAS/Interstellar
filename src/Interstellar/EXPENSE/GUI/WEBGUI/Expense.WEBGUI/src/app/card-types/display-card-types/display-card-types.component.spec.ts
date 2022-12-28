import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayCardTypesComponent } from './display-card-types.component';

describe('DisplayCardTypesComponent', () => {
  let component: DisplayCardTypesComponent;
  let fixture: ComponentFixture<DisplayCardTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayCardTypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayCardTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
