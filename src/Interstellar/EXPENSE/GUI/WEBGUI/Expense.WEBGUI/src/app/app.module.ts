import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CardModule } from './card/card.module';
import { LoginModule } from './Login/login.module';
import { RegisterUserComponent } from './Login/register-user/register-user.component';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, CardModule, LoginModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
