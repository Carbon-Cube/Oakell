import { Environment } from '@abp/ng.core';

const baseUrl = 'http://api.staging.oakell.com/';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Oakell',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://api.staging.oakell.com/',
    redirectUri: baseUrl,
    clientId: 'Oakell_App',
    responseType: 'code',
    scope: 'offline_access Oakell',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'http://api.staging.oakell.com/',
      rootNamespace: 'Oakell',
    },
  },
} as Environment;