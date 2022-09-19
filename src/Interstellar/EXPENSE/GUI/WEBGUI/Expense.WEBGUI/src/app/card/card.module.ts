import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CardData } from './Data/CardData';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [DisplayCardsComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    InMemoryWebApiModule.forRoot(CardData),
  ],
})
export class CardModule {}
