
import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-provider-states',
  templateUrl: './provider-states.component.html'
})
export class ProviderStatesComponent implements OnInit {
  public providers: Providers[];
  private headers: HttpHeaders;
  private baseUrl: string;
  public stateName: string;

  // combo files list view
  // shows all specialties by state (distinct types by state)
  constructor(private route: ActivatedRoute, private router: Router, private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.baseUrl = _baseUrl;
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }
  ngOnInit(): void {

console.log('TEST')
      this.route.queryParams.subscribe(params => {
        console.log(`ROUTER: ${params["stateName"]}`)
        this.stateName= params["stateName"];
        this.getByState(this.stateName);
      });
  }
  getByState(stateName: string) {
    // var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    // var body = JSON.stringify({stateName: stateName});
    return this.http
      .post<Providers[]>(this.baseUrl + `api/Provider/ProviderByState`, JSON.stringify({
        stateName: stateName
      }), {headers: this.headers})
      .subscribe(
        result => {
          this.providers = result;
        },
        error => console.error(error)
      );
  }

  goToCompleteDetail() {
      // navigate to provider state detail
      // this is the landing page for state and master file
  }
  goToDetail(provider)
  {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "providerState": provider.stateName,
          "providerType": provider.specialtyType
      }
    };

    this.router.navigate(["provider-state-details"],  navigationExtras);
  }
  getBySpecialtyType(specialty: string) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "specialty": specialty
      }
    };

    this.router.navigate(["provider-states-by-type"],  navigationExtras);
  }
}

interface Providers {
  id: string;
  stateName: string;
  specialtyType: string;
  recordCount: number;
}
