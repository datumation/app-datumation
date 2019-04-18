import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderStatesByTypeComponent } from './provider-states-by-type.component';

describe('ProviderStatesByTypeComponent', () => {
  let component: ProviderStatesByTypeComponent;
  let fixture: ComponentFixture<ProviderStatesByTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderStatesByTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderStatesByTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
