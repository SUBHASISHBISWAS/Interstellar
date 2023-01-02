import { Component } from '@angular/core';
import {
  BehaviorSubject,
  catchError,
  combineLatest,
  EMPTY,
  map,
  tap,
} from 'rxjs';
import { ExpenseService } from '../expense.service';

@Component({
  selector: 'app-display-expenses',
  templateUrl: './display-expenses.component.html',
  styleUrls: ['./display-expenses.component.css'],
})
export class DisplayExpensesComponent {
  pageTitle = 'Expenses';
  errorMessage = '';
  private expenseSelectedSubject = new BehaviorSubject<number>(0);
  expenseSelectedAction$ = this.expenseSelectedSubject.asObservable();
  allExpenses$ = this.expenseService.expenses$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  expenses$ = combineLatest([
    this.expenseService.expenses$,
    this.expenseSelectedAction$,
  ]).pipe(
    tap(([cardtypes, selectedCardTypeId]) => {
      console.log(cardtypes);
      console.log('Selected Card Type:: ' + selectedCardTypeId);
    }),
    map(([cardtypes, selectedCardTypeId]) =>
      cardtypes.filter((cardtype) =>
        selectedCardTypeId ? cardtype.id === selectedCardTypeId : true
      )
    ),
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  constructor(private expenseService: ExpenseService) {}

  onSelected(expenseId: string): void {
    this.expenseSelectedSubject.next(+expenseId);
  }
  onAdd(): void {
    console.log('Not yet implemented');
  }
}
