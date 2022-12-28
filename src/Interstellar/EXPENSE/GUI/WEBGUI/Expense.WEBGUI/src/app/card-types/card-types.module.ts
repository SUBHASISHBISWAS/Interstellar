import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { CardData } from '../card/Data/CardData';
import { SharedModule } from '../shared/shared.module';
import { CreateCardTypesComponent } from './create-card-types/create-card-types.component';
import { DisplayCardTypesComponent } from './display-card-types/display-card-types.component';

@NgModule({
  declarations: [CreateCardTypesComponent, DisplayCardTypesComponent],
  imports: [CommonModule, InMemoryWebApiModule.forRoot(CardData), SharedModule],
})
export class CardTypesModule {}
