import { TestBed } from '@angular/core/testing';

import { CardtypeService } from './cardtype.service';

describe('CardtypeService', () => {
  let service: CardtypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardtypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
