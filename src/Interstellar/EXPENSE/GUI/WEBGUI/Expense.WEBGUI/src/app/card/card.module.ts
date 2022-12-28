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
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { CreditCardDirective } from './Directives/CreditCardNumber';
import { OnlyNumberDirective } from './Directives/OnlyNuberForCardNumber';

@NgModule({
  declarations: [
    DisplayCardsComponent,
    CreateCardComponent,
    CreditCardDirective,
    OnlyNumberDirective,
  ],
  imports: [
    SharedModule,
    TextMaskModule,
    InMemoryWebApiModule.forRoot(CardData),
  ],
})
export class CardModule {}
