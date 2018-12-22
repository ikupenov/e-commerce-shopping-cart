import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';

import { environment } from '@env/environment';

@Injectable()
export class ApiBackendInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!req.url.startsWith('/')) {
      return;
    }

    req = req.clone({
      url: environment.apiEndpointUrl + req.url
    });

    return next.handle(req);
  }

}
