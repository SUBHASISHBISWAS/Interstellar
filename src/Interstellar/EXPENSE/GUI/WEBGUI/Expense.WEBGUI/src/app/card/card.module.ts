import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { CreateCardComponent } from './create-card/create-card.component';



@NgModule({
  declarations: [
    DisplayCardsComponent,
    CreateCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CardModule { }
