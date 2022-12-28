import { TestBed } from '@angular/core/testing';

import { CardTypeService } from './card-type.service';

describe('CardTypeService', () => {
  let service: CardTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
