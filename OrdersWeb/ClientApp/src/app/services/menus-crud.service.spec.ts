import { TestBed } from '@angular/core/testing';

import { MenusCrudService } from './menus-crud.service';

describe('MenusCrudService', () => {
  let service: MenusCrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MenusCrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
