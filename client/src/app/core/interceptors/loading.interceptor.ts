import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from 'src/app/core/services/busy.service';
import { delay, finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  constructor(private busyService: BusyService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (request.method === 'Post' && request.url.includes('orders')) {
      return next.handle(request);
    }
    if (request.method === 'DELETE') {
      return next.handle(request);
    }
    if (request.url.includes('emailexists')) {
      return next.handle(request);
    }
    this.busyService.busy();
    return next.handle(request).pipe(
      delay(100),
      finalize(() => {
        this.busyService.idle();
      })
    );
  }
}
