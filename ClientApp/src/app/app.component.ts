import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth/service/auth.service';
import { environment } from '../environments/environment';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  showSidebar: boolean;
  private publishableKey:string = environment.stripeKey;
  constructor(public auth: AuthService) {
    auth.handleAuthentication();

    this.showSidebar = false;
  }

  ngOnInit() {
    if (this.auth.isAuthenticated()) {
      this.auth.renewTokens();
    }

    // if (path) {
    //   this.showSidebar = false;
    // }

    // else{
    //   this.showSidebar = true;
    // }
  }
}
