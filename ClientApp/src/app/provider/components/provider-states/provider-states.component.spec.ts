import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderStatesComponent } from './provider-states.component';

describe('ProviderStatesComponent', () => {
  let component: ProviderStatesComponent;
  let fixture: ComponentFixture<ProviderStatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderStatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderStatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
