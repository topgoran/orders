import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberWrapperComponent } from './member-wrapper.component';

describe('MemberWrapperComponent', () => {
  let component: MemberWrapperComponent;
  let fixture: ComponentFixture<MemberWrapperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberWrapperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberWrapperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
