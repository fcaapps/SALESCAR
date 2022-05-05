import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatoriohtmlComponent } from './relatoriohtml.component';

describe('RelatoriohtmlComponent', () => {
  let component: RelatoriohtmlComponent;
  let fixture: ComponentFixture<RelatoriohtmlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RelatoriohtmlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RelatoriohtmlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
