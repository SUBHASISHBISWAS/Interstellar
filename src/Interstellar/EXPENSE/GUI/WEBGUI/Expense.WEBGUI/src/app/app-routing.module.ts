import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DisplayCardsComponent } from './card/display-cards/display-cards.component';
import { CreateCardComponent } from './card/create-card/create-card.component';

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot([
      {
        path: 'welcome',
        component: DisplayCardsComponent,
      },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: 'CreateCard', component: CreateCardComponent },
    ]),
    CommonModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
