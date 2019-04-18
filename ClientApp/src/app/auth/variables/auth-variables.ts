interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
  apiUrl: string;
}

export const AUTH_CONFIG: AuthConfig = {
  clientID: '67sKJGM5jeksIAusxzDRCPXmo8KeOa2C',
  domain: 'dev-4kr1gj3p.auth0.com',
  callbackURL: 'https://app-datumation.azurewebsites.net/callback',
  apiUrl: 'https://datumation/api'
};

interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
  apiUrl: string;
}
