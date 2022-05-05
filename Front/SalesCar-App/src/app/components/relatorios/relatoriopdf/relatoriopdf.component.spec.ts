import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatoriopdfComponent } from './relatoriopdf.component';

describe('RelatoriopdfComponent', () => {
  let component: RelatoriopdfComponent;
  let fixture: ComponentFixture<RelatoriopdfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RelatoriopdfComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RelatoriopdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
