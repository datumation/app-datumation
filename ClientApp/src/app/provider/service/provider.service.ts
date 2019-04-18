import { ProviderModel } from './../models/provider.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Injectable, Inject } from '@angular/core';
import { AuthService } from '../../auth/service/auth.service';

@Injectable()
export class ProviderService {

  private baseUrl: string;
public providers: ProviderModel[];
private headers: HttpHeaders;

constructor(public auth: AuthService,
  private http: HttpClient,
  @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = `${_baseUrl}api`;
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  // get provider model
  // providers on distinct state
  getAllProviderCombos() {

  }

  getAllProviderStates() {
    return this.http
    .get<ProviderModel[]>(
      `${this.baseUrl}/Provider/ProviderStates`);
  }

  // get all provider model
  //
  getAllProviderSpecialties() {
      return this.http
        .get<ProviderModel[]>(
          `${this.baseUrl}/Provider/ProviderSpecialties`);

  }
  getProviderStatesBySpecialty(specialty: string) {
    return this.http
    .post<ProviderModel[]>
    (`${this.baseUrl}/Provider/ProviderStatesBySpecialty`,
    JSON.stringify({
      specialty: specialty
    }), {headers: this.headers});

}

  downloadComboProviderFile(stateName: string) {
    if (this.auth.isAuthenticated()) {
        // get file
        // const states = this.stateDictionary();
        // const abbr = states.find(s => s.StateName === stateName);

        // window.open(`https://datumation1.blob.core.windows.net/states/${abbr.StateAbbr}.csv`, '_blank')
    }
  }

}
