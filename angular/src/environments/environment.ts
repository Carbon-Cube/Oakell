import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Oakell',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44380/',
    redirectUri: baseUrl,
    clientId: 'Oakell_App',
    responseType: 'code',
    scope: 'offline_access Oakell',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44380',
      rootNamespace: 'Oakell',
    },
  },
} as Environment;
