import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AracDetayComponent } from './arac-detay.component';

describe('AracDetayComponent', () => {
  let component: AracDetayComponent;
  let fixture: ComponentFixture<AracDetayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AracDetayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AracDetayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
