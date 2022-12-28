import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCardTypesComponent } from './create-card-types.component';

describe('CreateCardTypesComponent', () => {
  let component: CreateCardTypesComponent;
  let fixture: ComponentFixture<CreateCardTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCardTypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateCardTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
