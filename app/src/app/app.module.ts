import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';
import { RankGeralComponent } from './rank-geral/rank-geral.component';
import { MatSliderModule } from '@angular/material/slider';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTableModule} from '@angular/material/table'
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
   declarations: [
      AppComponent,
      RankGeralComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
      MatSliderModule,
      MatToolbarModule,
      BrowserModule,
      BrowserAnimationsModule,
      MatTableModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
