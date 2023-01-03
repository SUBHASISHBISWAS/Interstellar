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
  private expenseSelectedSubject = new BehaviorSubject<string>('');
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
    tap(([expenses, selectedExpenseId]) => {
      console.log(expenses);
      console.log('Selected Expense Id:: ' + selectedExpenseId);
    }),
    map(([expenses, selectedExpenseId]) =>
      expenses.filter((expense) =>
        selectedExpenseId != '0' ? expense.id === selectedExpenseId : true
      )
    ),
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  constructor(private expenseService: ExpenseService) {}

  onSelected(expenseId: string): void {
    this.expenseSelectedSubject.next(expenseId);
  }
  onAdd(): void {
    console.log('Not yet implemented');
  }
}
