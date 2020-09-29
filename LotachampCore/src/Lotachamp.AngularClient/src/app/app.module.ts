import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { RegisterScoreComponent } from './components/register-score/register-score.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ParticipantsComponent,
    SportsComponent,
    ToursComponent,
    TourDetailComponent,
    ScoresComponent,
    RegisterScoreComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'participants', component: ParticipantsComponent },
      { path: 'sports', component: SportsComponent },
      { path: 'tours', component: ToursComponent },
      { path: 'scores', component: ScoresComponent},
      { path: 'register', component: RegisterScoreComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [ParticipantsComponent, SportsComponent, ToursComponent, TourDetailComponent, ScoresComponent ]
})
export class AppModule { }
