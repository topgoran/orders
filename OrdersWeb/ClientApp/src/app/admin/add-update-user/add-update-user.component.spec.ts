import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateUserComponent } from './add-update-user.component';

describe('AddUpdateUserComponent', () => {
  let component: AddUpdateUserComponent;
  let fixture: ComponentFixture<AddUpdateUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
