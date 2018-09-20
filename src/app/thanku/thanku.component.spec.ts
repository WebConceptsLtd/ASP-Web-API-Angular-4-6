import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThankuComponent } from './thanku.component';

describe('ThankuComponent', () => {
  let component: ThankuComponent;
  let fixture: ComponentFixture<ThankuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThankuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThankuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
