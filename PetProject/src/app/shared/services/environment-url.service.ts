import { Injectable, Inject } from '@angular/core';

@Injectable()
export class EnvironmentUrlService {

  public urlAddress: string;
  
    constructor(@Inject('BASE_URL') baseUrl: string) {
        this.urlAddress = baseUrl;
    }

}
