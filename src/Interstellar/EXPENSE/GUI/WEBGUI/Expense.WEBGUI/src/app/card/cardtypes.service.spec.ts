import { TestBed } from '@angular/core/testing';

import { CardtypesService } from './cardtypes.service';

describe('CardtypesService', () => {
  let service: CardtypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardtypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
