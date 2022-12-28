import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap, throwError } from 'rxjs';
import { CardType } from './Models/CardTypes';

@Injectable({
  providedIn: 'root',
})
export class CardTypeService {
  private cardTypeInMemoryDataUrl = 'api/cardtypes';
  constructor(private http: HttpClient) {}

  cardTypes$ = this.http.get<CardType[]>(this.cardTypeInMemoryDataUrl).pipe(
    tap((data) => console.log('CardTypes: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  getCardType(id: number): Observable<CardType> {
    if (id === 0) {
      return of(this.initializeEmptyCardType());
    }
    const url = `${this.cardTypeInMemoryDataUrl}/${id}`;
    console.log(url);
    return this.http.get<CardType>(url).pipe(
      tap((data) => console.log('getCardTypes: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  createCardType(card: CardType): Observable<CardType> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<CardType>(this.cardTypeInMemoryDataUrl, card, { headers })
      .pipe(
        tap((data) => console.log('create Card: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  private initializeEmptyCardType(): CardType {
    // Return an initialized object
    return {
      id: 0,
      name: '',
      description: '',
      createdDate: undefined,
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
