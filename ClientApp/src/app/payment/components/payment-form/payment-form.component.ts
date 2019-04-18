import { ChargeResponseModel } from './../../models/stripe-charge-response.model';
import { environment } from "./../../../../environments/environment";

import { Component, OnInit, ViewChild, Input } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import {
  StripeService,
  StripeCardComponent,
  ElementOptions,
  ElementsOptions
} from "@nomadreservations/ngx-stripe";
// const stripe = Stripe('pk_test_pEYJlcUxkvLdXkPdl23gY92B00KNEsbcmc');
@Component({
  selector: "app-payment-form",
  templateUrl: "./payment-form.component.html",
  styleUrls: ["./payment-form.component.css"]
})
export class PaymentFormComponent implements OnInit {
  @ViewChild(StripeCardComponent) card: StripeCardComponent;

  // card options style
  @Input() price;
  @Input() product;
  @Input() description;

  cardOptions: ElementOptions = {
    style: {
      base: {
        iconColor: "#111",
        color: "#111",
        fontSize: "16px",
        "::placeholder": {
          color: "#111"
        }
      }
    }
  };

  // other optional options
  elementsOptions: ElementsOptions = {
    locale: "auto"
  };

  public chargeResponse: ChargeResponseModel;
public chargeModel: PaymentFormModel;
public productPrice: number;
public productDescription: string;

  constructor(
    private stripeService: StripeService,
    private httpclient: HttpClient
  ) {}
  public paymentForm = new FormGroup({
    name: new FormControl("", Validators.required),
    email: new FormControl("", Validators.required)
  });

  ngOnInit() {
    this.productPrice =500.0;
    this.productDescription = `stateName file for download`;
  }

  buy(formdata: FormData) {
    alert("TEST BUY");

    this.stripeService
      .createToken(this.card.getCard(), { name })
      .subscribe(result => {
        if (result.token) {
          const headers = new HttpHeaders().set(
            "Content-Type",
            "application/json"
          );

          alert(`PAYMENT SUCCESS! ${JSON.stringify(result)}`);
          // this.stripeService.createToken;

          this.chargeModel = new PaymentFormModel(
            formdata['email'],
             formdata['name'],
             this.productPrice,
             this.product,
             this.productDescription
          );


          // make a call to the server
          this.httpclient
            .post(
              `${environment.rootUrl}/api/Payments/Charge`,
              JSON.stringify({'chargeModel': this.chargeModel}),
              { headers: headers }
            )
            .subscribe(data => {
              console.log("---- Transaction Data -----");
              //message from the API
              console.log(data);
            });
          console.log(result.token.id);
        } else if (result.error) {
          console.log(result.error.message);
        }
      });
  }

}
export class PaymentFormModel {
  email: string;
  user: string;
  amount: number;
  product: string;
  description: string;

  /**
   *
   */
  constructor(em: string, user: string, amount: number, product: string, description: string) {
    this.email = em;
    this.user = user;
    this.amount = amount;
    this.product = product;
    this.description = description;
  }
}
