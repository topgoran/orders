import { TestBed } from '@angular/core/testing';

import { ArticlesCrudService } from './articles-crud.service';

describe('ArticlesCrudService', () => {
  let service: ArticlesCrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArticlesCrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
