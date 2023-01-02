import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap, throwError } from 'rxjs';
import { Expense } from './Models/Expense';

@Injectable({
  providedIn: 'root',
})
export class ExpenseService {
  private expensesInMemoryDataUrl = 'api/expenses';
  constructor(private http: HttpClient) {}

  expenses$ = this.http.get<Expense[]>(this.expensesInMemoryDataUrl).pipe(
    tap((data) => console.log('CardTypes: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  getExpense(id: number): Observable<Expense> {
    if (id === 0) {
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
      id: 0,
      expenseAmount: 0,
      expenseDescription: '',
      expenseDate: undefined,
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
