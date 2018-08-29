import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PetComponent } from './pet/pet.component';
import { RepositoryService } from './shared/services/repository.service';
import { EnvironmentUrlService } from './shared/services/environment-url.service';

@NgModule({
  declarations: [
    AppComponent,
    PetComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    EnvironmentUrlService,
    RepositoryService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
