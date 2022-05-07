import { ɵparseCookieValue } from "@angular/common";
import { NONE_TYPE } from "@angular/compiler";
import { KeycloakService } from "keycloak-angular";
import { environment } from "src/environments/environment";


export function initializeKeycloak(keycloak: KeycloakService) {
    return () =>
      keycloak.init({
        config: {
          url: environment.KEYCLOAK_URL,
          realm: "mefit",
          clientId: 'NgMefit'
        },
        initOptions: {
          checkLoginIframe: false,
          onLoad: 'login-required'
        },
        loadUserProfileAtStartUp: true
      });
  }