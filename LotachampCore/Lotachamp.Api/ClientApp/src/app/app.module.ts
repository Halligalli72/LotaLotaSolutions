import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ParticipantsComponent } from './components/participants/participants.component';
import { SportsComponent } from './components/sports/sports.component';
import { ToursComponent } from './components/tours/tours.component';
import { TourDetailComponent } from './components/tour-detail/tour-detail.component';
import { ScoresComponent } from './components/scores/scores.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ParticipantsComponent,
    SportsComponent,
    ToursComponent,
    TourDetailComponent,
    ScoresComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'participants', component: ParticipantsComponent },
      { path: 'sports', component: SportsComponent },
      { path: 'tours', component: ToursComponent },
      { path: 'scores', component: ScoresComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [ParticipantsComponent, SportsComponent, ToursComponent, TourDetailComponent, ScoresComponent]
})
export class AppModule { }
