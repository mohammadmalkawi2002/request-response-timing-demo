import { Injectable, signal } from '@angular/core';

export interface RequestTiming {
  method: string;
  url: string;
  clientDurationMs: number;
  serverDurationMs: number | null;
  isSlow: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class TimingService {

  readonly recentRequests = signal<RequestTiming[]>([]);

  setTiming(timing: RequestTiming): void {
    this.recentRequests.update(requests =>
      [timing, ...requests].slice(0, 3)
    );
  }
}
