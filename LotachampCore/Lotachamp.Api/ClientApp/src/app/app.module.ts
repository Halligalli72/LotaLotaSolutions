import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ParticipantListComponent } from './components/participant-list/participant-list.component';
import { SportListComponent } from './components/sport-list/sport-list.component';
import { TourListComponent } from './components/tour-list/tour-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ParticipantListComponent,
    SportListComponent,
    TourListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'participants', component: ParticipantListComponent },
      { path: 'sports', component: SportListComponent },
      { path: 'tours', component: TourListComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [ParticipantListComponent, SportListComponent, TourListComponent]
})
export class AppModule { }
