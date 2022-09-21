import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardData } from './Data/CardData';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { CreateCardComponent } from './create-card/create-card.component';
@NgModule({
  declarations: [DisplayCardsComponent, CreateCardComponent],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    InMemoryWebApiModule.forRoot(CardData),
  ],
})
export class CardModule {}
