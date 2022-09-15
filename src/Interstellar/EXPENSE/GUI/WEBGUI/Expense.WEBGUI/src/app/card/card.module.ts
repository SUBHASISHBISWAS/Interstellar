import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CardData } from './Data/CardData';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';

@NgModule({
  declarations: [DisplayCardsComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InMemoryWebApiModule.forRoot(CardData),
  ],
})
export class CardModule {}
