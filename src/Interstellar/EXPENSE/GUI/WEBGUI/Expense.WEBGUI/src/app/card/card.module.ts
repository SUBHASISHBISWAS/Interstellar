import { NgModule } from '@angular/core';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { TextMaskModule } from 'angular2-text-mask';
import { SharedModule } from '../shared/shared.module';
import { CreateCardComponent } from './create-card/create-card.component';
import { CardData } from './Data/CardData';
import { CreditCardDirective } from './Directives/CreditCardNumber';
import { OnlyNumberDirective } from './Directives/OnlyNuberForCardNumber';
import { DisplayCardsComponent } from './display-cards/display-cards.component';

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
