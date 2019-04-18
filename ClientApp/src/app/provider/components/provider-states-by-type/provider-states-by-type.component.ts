import { ProviderModel } from './../../models/provider.model';
import { ProviderService } from './../../service/provider.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';

@Component({
  selector: 'app-provider-states-by-type',
  templateUrl: './provider-states-by-type.component.html',
  styleUrls: ['./provider-states-by-type.component.css']
})
export class ProviderStatesByTypeComponent implements OnInit {
  private specialty: string;
  providers;
  constructor(private route: ActivatedRoute,
    private router: Router,
    private _provider: ProviderService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      console.log(`ROUTER: ${params["specialty"]}`)
      this.specialty= params["specialty"];
      this.getBySpecialty(this.specialty);
    });
  }
  getBySpecialty(specialty: string) {
    // var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    // var body = JSON.stringify({stateName: stateName});
    this._provider.getProviderStatesBySpecialty(specialty)
      .subscribe(
        result => {
          this.providers = result;
        },
        error => console.error(error)
      );
  }

  getByState(stateName) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "stateName": stateName
      }
    };

    this.router.navigate(["provider-states"],  navigationExtras);
  }
  goToDetails(provider: ProviderModel) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "providerState": provider.stateName,
          "providerType": provider.specialtyType
      }
    };

    this.router.navigate(["provider-combo-details"],  navigationExtras);
  }
}
