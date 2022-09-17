import { TestBed } from '@angular/core/testing';

import { CardcategoriesService } from './cardcategories.service';

describe('CardcategoriesService', () => {
  let service: CardcategoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardcategoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
