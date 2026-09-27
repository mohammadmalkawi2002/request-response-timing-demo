import { HttpInterceptorFn, HttpResponse } from "@angular/common/http";
import { finalize, tap } from 'rxjs';
import { inject } from '@angular/core';
import { TimingService } from '../services/timing.service';


export const requestTimingInterceptor: HttpInterceptorFn = (req, next) => {
  const timingService = inject(TimingService);
  const slowRequestThresholdMs = 1000;
  const startTime = performance.now();

  let serverDuration: string | null = null;

  return next(req).pipe(
    tap(event => {
      if (event instanceof HttpResponse) {
        serverDuration = event.headers.get('X-Response-Time-ms');
      }
    }),

    finalize(() => {
      const duration = performance.now() - startTime;

      const serverDurationMs =
        serverDuration !== null
          ? Number(serverDuration)
          : null;

      timingService.setTiming({
        method: req.method,
        url: req.urlWithParams,
        clientDurationMs: duration,
        serverDurationMs,
        isSlow: duration >= slowRequestThresholdMs
      });

      const message =
        `HTTP ${req.method} ${req.urlWithParams} completed in ${duration.toFixed(2)} ms | Server: ${serverDuration ?? 'N/A'} ms`;

      if (duration >= slowRequestThresholdMs) {
        console.warn(`Slow ${message}`);
      } else {
        console.log(message);
      }
    })
  );
};
