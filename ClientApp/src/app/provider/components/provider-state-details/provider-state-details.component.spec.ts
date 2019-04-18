import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderStateDetailsComponent } from './provider-state-details.component';

describe('ProviderStateDetailsComponent', () => {
  let component: ProviderStateDetailsComponent;
  let fixture: ComponentFixture<ProviderStateDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderStateDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderStateDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
