import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviderComboDetailsComponent } from './provider-combo-details.component';

describe('ProviderComboDetailsComponent', () => {
  let component: ProviderComboDetailsComponent;
  let fixture: ComponentFixture<ProviderComboDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviderComboDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviderComboDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
