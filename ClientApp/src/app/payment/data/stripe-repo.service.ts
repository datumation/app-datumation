import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StripeChargeModel } from '../models/stripe-charge.model';
import { ChargeResponseModel } from '../models/stripe-charge-response.model';

@Injectable()
export class StripeRepoService {
  private headers: HttpHeaders;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  public chargePayment(chargeModel: StripeChargeModel) {
    return this.http.post<ChargeResponseModel>(`${environment.rootUrl}/Payments/Charge`,
    JSON.stringify({
      chargeModel: chargeModel
    }), {headers: this.headers});
  }

}
