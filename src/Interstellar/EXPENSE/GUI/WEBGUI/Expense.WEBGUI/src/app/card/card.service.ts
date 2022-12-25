import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap, throwError } from 'rxjs';
import {
  combineLatest,
  combineLatestInit,
} from 'rxjs/internal/observable/combineLatest';
import { Card } from './Models/Card';
import { CardType } from './Models/CardTypes';

@Injectable({
  providedIn: 'root',
})
export class CardService {
  private cardInMemoryDataUrl = '/api/cards';
  private cardTypeInMemoryDataUrl = 'api/cardtypes';

  cards$ = this.http.get<Card[]>(this.cardInMemoryDataUrl).pipe(
    tap((data) => console.log('Cards: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  cardTypes$ = this.http.get<CardType[]>(this.cardTypeInMemoryDataUrl).pipe(
    tap((data) => console.log('CardTypes: ', JSON.stringify(data))),
    catchError(this.handleError)
  );

  cardWithCardType$ = combineLatest([this.cards$, this.cardTypes$]).pipe(
    map(([cards, cardTypes]) =>
      cards.map(
        (card) =>
          ({
            ...card,
            cardType: cardTypes.find((ct) => card.cardTypeId == ct.id)?.name,
          } as Card)
      )
    )
  );

  constructor(private http: HttpClient) {}

  getCard(cardId: number): Observable<Card> {
    if (cardId === 0) {
      return of(this.initializeEmptyCard());
    }
    const url = `${this.cardInMemoryDataUrl}/${cardId}`;
    return this.http.get<Card>(url).pipe(
      tap((data) => console.log('getCard: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  createCard(card: Card): Observable<Card> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .post<Card>(this.cardInMemoryDataUrl, card, { headers })
      .pipe(
        tap((data) => console.log('create Card: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  private initializeEmptyCard(): Card {
    // Return an initialized object
    return {
      cardId: 0,
      cardName: 'HDFC',
      cardTypeId: 1,
      cardNumber: '1234-1234-1234-1234',
      cardDescription: 'HDFC BANK CARD',
      cardExpiryDate: new Date('15-10-1983'),
      cardStatementDate: new Date('15-10-1983'),
      cardDueDate: new Date('15-10-1983'),
      cardNextStatementDate: new Date('15-10-1983'),
      gracePeriod: 50,
      cardCurrentMonthExpenditure: 100,
      cardNextMonthExpenditure: 1000,
      cardTotalExpenditure: 10000,
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
