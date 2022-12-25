import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DisplayCardsComponent } from './card/display-cards/display-cards.component';
import { CreateCardComponent } from './card/create-card/create-card.component';
import { RegisterUserComponent } from './Login/register-user/register-user.component';

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
