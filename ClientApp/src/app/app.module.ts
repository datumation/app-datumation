
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Import your library

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
// Import your library
import { NgxStripeModule } from '@nomadreservations/ngx-stripe';
import { ProfileComponent } from './profile/profile.component';
import { ProviderTypeDetailsComponent } from './provider/components/provider-type-details/provider-type-details.component';
import { ProviderStateDetailComponent } from './provider/components/provider-state-details/provider-state-details.component';
import { StripePaymentService } from './payment/service/stripe-payment.service';
import { CounterComponent } from './counter/counter.component';
import { ProviderTypesComponent } from './provider/components/provider-types/provider-types.component';
import { ProviderStatesComponent } from './provider/components/provider-states/provider-states.component';
import { ProviderTypeByStateComponent } from './provider/components/provider-type-by-state/provider-type-by-state.component';
import { ProviderStatesByTypeComponent } from './provider/components/provider-states-by-type/provider-states-by-type.component';
import { AuthService } from './auth/service/auth.service';
import { ProviderComboDetailsComponent } from './provider/components/provider-combo-details/provider-combo-details.component';
import { AuthGuardService } from './auth/service/auth-guard.service';
import { ProviderService} from './provider/service/provider.service';
import { CallbackComponent } from './callback/callback.component';
import { PaymentFormComponent } from './payment/components/payment-form/payment-form.component';
import { environment } from '../environments/environment';
import { PaymentRegistrationComponent } from './payment/components/payment-registration/payment-registration.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    ProviderTypesComponent,
    ProviderStatesComponent,
    ProviderTypeByStateComponent,
    ProviderStatesByTypeComponent,
    ProviderComboDetailsComponent,
    ProviderStateDetailComponent,
    PaymentFormComponent,
    ProfileComponent,
    ProviderTypeDetailsComponent,
    CallbackComponent,
    PaymentFormComponent,
    PaymentRegistrationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgxStripeModule.forRoot(`${environment.stripeKey}`),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      {path: 'provider-types', component: ProviderTypesComponent},
      {path: 'provider-states-by-type', component: ProviderStatesByTypeComponent},
      {path: 'provider-type-by-state', component: ProviderTypeByStateComponent},
      {path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService]},
      {path: 'provider-combo-details', component: ProviderComboDetailsComponent},
      {path: 'provider-states', component: ProviderStatesComponent},
      {path: 'provider-state-details', component: ProviderStateDetailComponent},
      {path: 'provider-type-details', component: ProviderTypeDetailsComponent},
      {path: 'callback', component: CallbackComponent},
      {path: 'payment-form', component: PaymentFormComponent},
      {path: '**', redirectTo: ''},
      { path: 'provider-types', component: ProviderTypesComponent },
    ])
  ],
  providers: [AuthService, AuthGuardService, ProviderService, StripePaymentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
