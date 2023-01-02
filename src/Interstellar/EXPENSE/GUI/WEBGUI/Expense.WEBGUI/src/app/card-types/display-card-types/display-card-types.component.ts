import { Component } from '@angular/core';
import { Guid } from 'guid-typescript';
import {
  BehaviorSubject,
  catchError,
  combineLatest,
  EMPTY,
  map,
  tap,
} from 'rxjs';
import { CardService } from 'src/app/card/card.service';

@Component({
  selector: 'app-display-card-types',
  templateUrl: './display-card-types.component.html',
  styleUrls: ['./display-card-types.component.css'],
})
export class DisplayCardTypesComponent {
  pageTitle = 'Card Types';
  errorMessage = '';
  private cardTypeSelectedSubject = new BehaviorSubject<string>('');
  cardTypeSelectedAction$ = this.cardTypeSelectedSubject.asObservable();
  allCardTypes$ = this.cardService.cardTypes$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  cardTypes$ = combineLatest([
    this.cardService.cardTypes$,
    this.cardTypeSelectedAction$,
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

  constructor(private cardService: CardService) {}

  onSelected(cardTypeId: string): void {
    console.log('Hello' + Guid.isGuid(cardTypeId) + cardTypeId);
    this.cardTypeSelectedSubject.next(cardTypeId);
  }
  onAdd(): void {
    console.log('Not yet implemented');
  }
}
