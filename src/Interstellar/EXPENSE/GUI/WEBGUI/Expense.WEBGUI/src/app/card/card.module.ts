import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardsComponent } from './display-cards/display-cards.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [DisplayCardsComponent],
  imports: [CommonModule, ReactiveFormsModule],
})
export class CardModule {}
