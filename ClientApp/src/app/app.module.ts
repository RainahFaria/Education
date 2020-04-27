import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SchoolComponent } from './Components/school/school.component';
import { ClassroomComponent } from './Components/classroom/classroom.component';
import { SchoolService } from './services/school.service';
import { ClassroomService } from './services/classroom.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './Components/home/home.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    SchoolComponent,
    ClassroomComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,    
    FormsModule
  ],
  providers: [
    SchoolService,
    ClassroomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
