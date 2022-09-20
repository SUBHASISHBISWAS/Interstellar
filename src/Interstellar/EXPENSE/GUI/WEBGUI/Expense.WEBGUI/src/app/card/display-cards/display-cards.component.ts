import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  BehaviorSubject,
  catchError,
  EMPTY,
  filter,
  map,
  Subject,
  tap,
} from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { CardService } from '../card.service';

@Component({
  selector: 'app-display-cards',
  templateUrl: './display-cards.component.html',
  styleUrls: ['./display-cards.component.css'],
})
export class DisplayCardsComponent implements OnInit {
  pageTitle = 'Cards';

  private cardTypeSelectedSubject = new Subject<number>();
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
        selectedCardTypeId ? card.cardTypeId === selectedCardTypeId : true
      )
    ),
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  errorMessage = '';
  cardForm!: FormGroup;

  constructor(private fb: FormBuilder, private cardService: CardService) {}

  ngOnInit(): void {
    this.cardService.cards$.subscribe((card) => console.log(card));
    this.cardForm = this.fb.group({
      cardName: null,
      cardNumber: null,
    });
  }

  onAdd(): void {
    console.log('Not yet implemented');
  }

  onSelected(cardTypeId: string): void {
    this.cardTypeSelectedSubject.next(+cardTypeId);
  }
}
