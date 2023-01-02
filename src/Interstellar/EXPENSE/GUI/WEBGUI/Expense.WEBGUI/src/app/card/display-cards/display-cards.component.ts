import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BehaviorSubject, catchError, EMPTY, map, tap } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { CardService } from '../card.service';

@Component({
  selector: 'app-display-cards',
  templateUrl: './display-cards.component.html',
  styleUrls: ['./display-cards.component.css'],
})
export class DisplayCardsComponent implements OnInit {
  pageTitle = 'Cards';
  errorMessage = '';
  cardForm!: FormGroup;

  private cardTypeSelectedSubject = new BehaviorSubject<string>('');
  cardTypeSelectedAction$ = this.cardTypeSelectedSubject.asObservable();

  cardTypes$ = this.cardService.cardTypes$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  cards$ = combineLatest([
    this.cardService.cards$,
    this.cardTypeSelectedAction$,
  ]).pipe(
    tap(([cards, selectedCardTypeId]) => {
      console.log(cards);
      console.log('Selected Card Type:: ' + selectedCardTypeId);
    }),
    map(([products, selectedCardTypeId]) =>
      products.filter((card) =>
        selectedCardTypeId
          ? card.cardTypeId.toString() === selectedCardTypeId.toString()
          : true
      )
    ),
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  constructor(private cardService: CardService) {}

  ngOnInit(): void {}

  onAdd(): void {
    console.log('Not yet implemented');
  }

  onSelected(cardTypeId: string): void {
    this.cardTypeSelectedSubject.next(cardTypeId);
  }
}
