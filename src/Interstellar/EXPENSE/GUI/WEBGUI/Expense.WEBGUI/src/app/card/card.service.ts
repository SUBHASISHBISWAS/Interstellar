import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { Card } from './Models/Card';
import { CardType } from './Models/CardTypes';

@Injectable({
  providedIn: 'root',
})
export class CardService {
  private cardUrl = 'api/cards';
  private cardTypeUrl = 'api/cardtypes';

  cards$ = this.http.get<Card[]>(this.cardUrl).pipe(
    tap((data) => console.log('Cards: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  cardTypes$ = this.http.get<CardType[]>(this.cardTypeUrl).pipe(
    tap((data) => console.log('CardTypes: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  constructor(private http: HttpClient) {}

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
