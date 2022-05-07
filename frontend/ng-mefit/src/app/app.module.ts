import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import {CalendarModule as PrimeNGCalendarModule} from 'primeng/calendar';

import { AppComponent } from './app.component';
import { DashboardPage } from './pages/dashboard/dashboard.page';
import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';
import { initializeKeycloak } from '../app/utils/app.init';
import { HeaderComponent } from '../app/components/header/header.component';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { CommonModule } from '@angular/common';
import { CalendarComponent } from './components/calendar/calendar.component';
import { ProgressFormComponent } from './components/progress-form/progress-form.component';
import { HttpClientModule } from '@angular/common/http';
import { ProgramsPage } from './pages/programs/programs.page';
import { ProgramListItemComponent } from './components/program-list-item/program-list-item.component';
import { WorkoutListItemComponent } from './components/workout-list-item/workout-list-item.component';
import { WorkoutListComponent } from './components/workout-list/workout-list.component';
import { ProfilePage } from './pages/profile/profile.page';
import { AdminRequestComponent } from './components/admin-request/admin-request.component';
import { AdminPage } from './pages/admin/admin.page';
import { AdminListComponent } from './components/admin-list/admin-list.component';
import { ProgramDetailsComponent } from './components/program-details/program-details.component';
import { ProgramListComponent } from './components/program-list/program-list.component';
import { CreateGoalButtonComponent } from './components/create-goal-button/create-goal-button.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardPage,
    HeaderComponent,
    CalendarComponent,
    ProgressFormComponent,
    ProgramsPage,
    ProgramListItemComponent,
    WorkoutListItemComponent,
    WorkoutListComponent,
    ProfilePage,
    AdminRequestComponent,
    AdminPage,
    AdminListComponent,
    ProgramDetailsComponent,
    ProgramListComponent,
    CreateGoalButtonComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    KeycloakAngularModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    PrimeNGCalendarModule,
    NgbModule,
    NgbModalModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeKeycloak,
      multi: true,
      deps: [KeycloakService]
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
