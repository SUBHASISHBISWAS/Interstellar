import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateCardTypesComponent } from '../card-types/create-card-types/create-card-types.component';
import { DisplayCardTypesComponent } from '../card-types/display-card-types/display-card-types.component';
import { CreateCardComponent } from '../card/create-card/create-card.component';
import { DisplayCardsComponent } from '../card/display-cards/display-cards.component';
import { CardGuard } from '../card/Guards/card.guard';
import { RegisterUserComponent } from '../Login/register-user/register-user.component';

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot([
      {
        path: 'welcome',
        component: DisplayCardsComponent,
      },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      {
        path: 'cards/:cardId/edit',
        canDeactivate: [CardGuard],
        component: CreateCardComponent,
      },
      {
        path: 'cardtypes/:id/edit',
        component: CreateCardTypesComponent,
      },
      {
        path: 'cardtypes',
        component: DisplayCardTypesComponent,
      },
      { path: 'RegisterUser', component: RegisterUserComponent },
    ]),
    CommonModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {
  paths = [
    {
      path: 'welcome',
      component: DisplayCardsComponent,
    },
    { path: '', redirectTo: 'welcome', pathMatch: 'full' },
    { path: 'CreateCard', component: CreateCardComponent },
    { path: 'RegisterUser', component: RegisterUserComponent },
  ];
}
