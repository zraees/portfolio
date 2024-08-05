import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostGemsComponent } from './most-gems.component';

describe('MostGemsComponent', () => {
  let component: MostGemsComponent;
  let fixture: ComponentFixture<MostGemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MostGemsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MostGemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
