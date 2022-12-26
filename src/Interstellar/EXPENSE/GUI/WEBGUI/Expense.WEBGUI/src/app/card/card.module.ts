import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardData } from './Data/CardData';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { CreateCardComponent } from './create-card/create-card.component';
import { TextMaskModule } from 'angular2-text-mask';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [DisplayCardsComponent, CreateCardComponent],
  imports: [
    SharedModule,
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TextMaskModule,
    RouterModule,
    InMemoryWebApiModule.forRoot(CardData),
  ],
})
export class CardModule {}
