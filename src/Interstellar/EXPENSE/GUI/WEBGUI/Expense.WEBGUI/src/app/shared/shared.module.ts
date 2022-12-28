import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../Routing/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    ButtonsModule.forRoot(),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    AppRoutingModule,
    BrowserModule,
    BsDatepickerModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ButtonsModule,
    RouterModule,
  ],
})
export class SharedModule {}
