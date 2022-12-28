import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCardTypesComponent } from './create-card-types/create-card-types.component';
import { DisplayCardTypesComponent } from './display-card-types/display-card-types.component';

@NgModule({
  declarations: [
    CreateCardTypesComponent,
    DisplayCardTypesComponent
  ],
  imports: [CommonModule],
})
export class CardTypesModule {}
