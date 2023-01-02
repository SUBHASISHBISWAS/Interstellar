import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { CardService } from '../card/card.service';
import { CardInMemoryMockData } from '../Data/CardInmemoryMockData';
import { SharedModule } from '../shared/shared.module';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { DisplayExpensesComponent } from './display-expenses/display-expenses.component';

@NgModule({
  declarations: [AddExpenseComponent, DisplayExpensesComponent],
  imports: [
    CommonModule,
    InMemoryWebApiModule.forRoot(CardInMemoryMockData),
    SharedModule,
  ],
  providers: [CardService],
})
export class ExpenseModule {}
