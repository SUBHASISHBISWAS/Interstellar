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

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, CardModule, LoginModule],
  providers: [DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
