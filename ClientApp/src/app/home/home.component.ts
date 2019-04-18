import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/service/auth.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  siteName: string;
  currentYear: string;
   public homeContent: LandingPageContent[] = [];
   public homeGraphics: LandingPageGraphics[] = [];
  public homeFrontGraphic ={
    'padding': '5%',
    'background':"url('/assets/hero-bg-front.png')"
};
  public homeBackGraphic = {
    'padding': '5%',
    'background':"url('/assets/hero-bg-back.jpg')"
  };
  constructor(public auth: AuthService) {
    auth.handleAuthentication();
    this.siteName = `Datumation`;
    this.homeContent.push({
      'contentText' : 'Datumation',
      'cssClass': 'mainContentText'
    });
    this.homeContent.push({
      'contentText' : 'Provider Data',
      'cssClass': 'mainContentText'
    });
    this.homeContent.push({
      'contentText' : 'Coming Soon',
      'cssClass': 'mainContentText'
    });
    this.currentYear = new Date().getFullYear().toString();

  }





  ngOnInit() {


    if (this.auth.isAuthenticated()) {

      this.auth.renewTokens();

    }
  }


}

export interface LandingPageContent {
   contentText: string;
   cssClass: string;

}

export interface LandingPageGraphics {
   imageName: string;
   imageSrc: string;
   imageCss: any;
}
export interface CssModel {
   cssKey: string;
   cssValue: string;
  }
