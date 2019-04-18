import { Router, NavigationExtras } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ProviderService } from './../../service/provider.service';
import { ProviderModel } from './../../models/provider.model';

@Component({
  selector: 'app-provider-types',
  templateUrl: './provider-types.component.html',
  styleUrls: ['./provider-types.component.css']
})
export class ProviderTypesComponent implements OnInit {
  providers: ProviderModel[];

  constructor(private _provider: ProviderService, private router: Router) { }

  ngOnInit() {
    this.getProviderStateList();
  }

  getProviderStateList() {
      this._provider.getAllProviderSpecialties()
      .subscribe(result => {
        this.providers = result;
      }, error => console.error(error));
  }
  getBySpecialtyType(specialty: string) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "specialty": specialty
      }
    };

    this.router.navigate(["provider-states-by-type"],  navigationExtras);
  }
  getByState(stateName) {

  }
  goToDetails(specialty:string) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
          "specialty": specialty
      }
    };

    this.router.navigate(["provider-type-details"],  navigationExtras);
  }
}
