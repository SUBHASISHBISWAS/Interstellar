import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import {
  catchError,
  combineLatest,
  EMPTY,
  map,
  Observable,
  of,
  tap,
  throwError,
} from 'rxjs';
import { CardService } from '../card/card.service';
import { Expense } from './Models/Expense';

@Injectable({
  providedIn: 'root',
})
export class ExpenseService {
  private expensesInMemoryDataUrl = 'api/expenses';
  constructor(private http: HttpClient, private cardService: CardService) {}

  private expenses = this.http
    .get<Expense[]>(this.expensesInMemoryDataUrl)
    .pipe(
      tap((data) => console.log('expenses: ', JSON.stringify(data))),
      catchError(this.handleError)
    );

  cards$ = this.cardService.cards$;
  expenses$ = combineLatest([this.expenses, this.cards$]).pipe(
    tap(([expenses, cards]) => {
      console.log(expenses);
      console.log('Selected Expense Id:: ' + cards);
    }),
    map(([expenses, cards]) =>
      expenses.map(
        (expense) =>
          ({
            ...expense,
            expenseCard: cards.find((c) => expense.expenseCardId === c.cardId)
              ?.cardName,
          } as Expense)
      )
    ),
    catchError((err) => {
      return EMPTY;
    })
  );

  getExpense(id: string): Observable<Expense> {
    if (Guid.parse(id).isEmpty()) {
      return of(this.initializeExpense());
    }
    const url = `${this.expensesInMemoryDataUrl}/${id}`;
    console.log(url);
    return this.http.get<Expense>(url).pipe(
      tap((data) => console.log('getCardTypes: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  addExpense(card: Expense): Observable<Expense> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<Expense>(this.expensesInMemoryDataUrl, card, { headers })
      .pipe(
        tap((data) => console.log('create Card: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  private initializeExpense(): Expense {
    // Return an initialized object
    return {
      id: Guid.createEmpty().toString(),
      expenseAmount: 0,
      expenseDescription: '',
      expenseDate: undefined,
      expenseCardId: Guid.createEmpty().toString(),
    };
  }

  private handleError(err: HttpErrorResponse): Observable<never> {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.message}`;
    }
    console.error(err);
    return throwError(() => errorMessage);
  }
}
