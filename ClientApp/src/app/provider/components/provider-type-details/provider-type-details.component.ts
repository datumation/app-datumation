import { AuthService } from '../../../auth/service/auth.service';
import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { state } from '@angular/animations';
import { ProviderModel as Providers } from '../../models/provider.model';
@Component({
  selector: 'app-provider-type-details',
  templateUrl: './provider-type-details.component.html',
  styleUrls: ['./provider-type-details.component.css']
})



// detail view for complete state file
// buy the master <TX> file</TX> or any other state
// defer to the provider-combodetail for the state and type file
export class ProviderTypeDetailsComponent implements OnInit {
public providerInfo;
attemptPurchase: boolean;
purchaseConfirm: boolean;
messagePrompt: boolean;
constructor(private route: ActivatedRoute, private router: Router,
  public auth: AuthService, private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {

  this.attemptPurchase = false;
  this.purchaseConfirm = false;
  this.messagePrompt = false;

}

  ngOnInit() {

    const provider = {
      'stateName': `Complete for Specialty`,
      'specialtyType':  this.route.queryParams['value']['specialty'],
    };
    this.providerInfo = provider;

  }

  showToaster() {
    const style  = 'opacity:1;display:block;';
    return style;
  }
buyNow(stateName: string) {
  this.attemptPurchase = true;
  this.toggle_class();

}

stateDictionary() {
  const states = new Array<StateModel>();
  states.push(new StateModel("Alabama", "AL"))
  states.push(new StateModel("Alaska", "AK"))
  states.push(new StateModel("Arizona", "AZ"))
  states.push(new StateModel("Arkansas", "AR"))
  states.push(new StateModel("California", "CA"))
  states.push(new StateModel("Colorado", "CO"))
  states.push(new StateModel("Connecticut", "CT"))
  states.push(new StateModel("Delaware", "DE"))
  states.push(new StateModel("District of Columbia", "DC"))
  states.push(new StateModel("Florida", "FL"))
  states.push(new StateModel("Georgia", "GA"))
  states.push(new StateModel("Hawaii", "HI"))
  states.push(new StateModel("Idaho", "ID"))
  states.push(new StateModel("Illinois", "IL"))
  states.push(new StateModel("Indiana", "IN"))
  states.push(new StateModel("Iowa", "IA"))
  states.push(new StateModel("Kansas", "KS"))
  states.push(new StateModel("Kentucky", "KY"))
  states.push(new StateModel("Louisiana", "LA"))
  states.push(new StateModel("Maine", "ME"))
  states.push(new StateModel("Montana", "MT"))
  states.push(new StateModel("Nebraska", "NE"))
  states.push(new StateModel("Nevada", "NV"))
  states.push(new StateModel("New Hampshire", "NH"))
  states.push(new StateModel("New Jersey", "NJ"))
  states.push(new StateModel("New Mexico", "NM"))
  states.push(new StateModel("New York", "NY"))
  states.push(new StateModel("North Carolina", "NC"))
  states.push(new StateModel("North Dakota", "ND"))
  states.push(new StateModel("Ohio", "OH"))
  states.push(new StateModel("Oklahoma", "OK"))
  states.push(new StateModel("Oregon", "OR"))
  states.push(new StateModel("Maryland", "MD"))
  states.push(new StateModel("Massachusetts", "MA"))
  states.push(new StateModel("Michigan", "MI"))
  states.push(new StateModel("Minnesota", "MN"))
  states.push(new StateModel("Mississippi", "MS"))
  states.push(new StateModel("Missouri", "MO"))
  states.push(new StateModel("Pennsylvania", "PA"))
  states.push(new StateModel("Rhode Island", "RI"))
  states.push(new StateModel("South Carolina", "SC"))
  states.push(new StateModel("South Dakota", "SD"))
  states.push(new StateModel("Tennessee", "TN"))
  states.push(new StateModel("Texas", "TX"))
  states.push(new StateModel("Utah", "UT"))
  states.push(new StateModel("Vermont", "VT"))
  states.push(new StateModel("Virginia", "VA"))
  states.push(new StateModel("Washington", "WA"))
  states.push(new StateModel("West Virginia", "WV"))
  states.push(new StateModel("Wisconsin", "WI"))
  states.push(new StateModel("Wyoming", "WY"))
return states;
}

public my_Class = 'noToast';

toggle_class(){
  if(this.my_Class=="noToast"){
      this.my_Class='showToast';
  }else{
      this.my_Class='noToast';
  }
}
dismissToast() {
  this.attemptPurchase = false;
  this.purchaseConfirm = false;
  this.toggle_class();
}


downloadConfirm(stateName: string)
{
  this.purchaseConfirm = true;
  this.toggle_class();
}
  downloadStateFile(stateName: string) {
    if (this.auth.isAuthenticated()) {
        // get file
        const states = this.stateDictionary();
        const abbr = states.find(s => s.StateName === stateName);

        window.open(`https://datumation1.blob.core.windows.net/states/${abbr.StateAbbr}.csv`, '_blank')
    }
  }

}
export class StateModel
{
  StateName: string;
  StateAbbr: string;
  /**
   *
   */
  constructor(_stateName: string, _stateAbbr: string) {
    this.StateName = _stateName;
    this.StateAbbr = _stateAbbr;
  }
}
