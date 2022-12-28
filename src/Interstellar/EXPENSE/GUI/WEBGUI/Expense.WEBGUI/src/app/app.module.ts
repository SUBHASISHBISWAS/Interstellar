import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { AppRoutingModule } from './Routing/app-routing.module';

import { AppComponent } from './app.component';
import { CardModule } from './card/card.module';
import { LoginModule } from './Login/login.module';
import { RegisterUserComponent } from './Login/register-user/register-user.component';
import { DatePipe } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    SharedModule,
    CardModule,
    LoginModule,
    
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
