export interface StripeChargeModel
{
  token: string;
  email: string;
  user: string;
  amount: number;
  product: string;
  description: string;
}
