import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderTypeByStateComponent } from './provider-type-by-state.component';

describe('ProviderTypeByStateComponent', () => {
  let component: ProviderTypeByStateComponent;
  let fixture: ComponentFixture<ProviderTypeByStateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderTypeByStateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderTypeByStateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
