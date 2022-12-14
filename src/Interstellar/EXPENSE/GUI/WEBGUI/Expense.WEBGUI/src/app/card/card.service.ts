import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { catchError, map, Observable, of, tap, throwError } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { CardTypeService } from '../card-types/card-type.service';
import { Card } from './Models/Card';

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

  cardTypes$ = this.cardTypeService.cardTypes$;
  /*
  cardTypes$ = this.http.get<CardType[]>(this.cardTypeInMemoryDataUrl).pipe(
    tap((data) => console.log('CardTypes: ', JSON.stringify(data))),
    catchError(this.handleError)
  );
  */

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

  constructor(
    private http: HttpClient,
    private cardTypeService: CardTypeService
  ) {}

  getCard(cardId: string): Observable<Card> {
    if (Guid.parse(cardId).isEmpty()) {
      return of(this.initializeEmptyCard());
    }
    const url = `${this.cardInMemoryDataUrl}/${cardId}`;
    console.log(url);
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
      id: Guid.createEmpty().toString(),
      cardId: Guid.createEmpty().toString(),
      cardName: '',
      cardTypeId: Guid.createEmpty().toString(),
      cardNumber: ' ',
      cardDescription: '',
      cardExpiryDate: undefined,
      cardStatementDate: undefined,
      cardDueDate: undefined,
      cardNextStatementDate: undefined,
      gracePeriod: 0,
      cardCurrentMonthExpenditure: 0,
      cardNextMonthExpenditure: 0,
      cardTotalExpenditure: 0,
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
