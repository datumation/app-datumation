import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderTypeDetailsComponent } from './provider-type-details.component';

describe('ProviderTypeDetailsComponent', () => {
  let component: ProviderTypeDetailsComponent;
  let fixture: ComponentFixture<ProviderTypeDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderTypeDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderTypeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
