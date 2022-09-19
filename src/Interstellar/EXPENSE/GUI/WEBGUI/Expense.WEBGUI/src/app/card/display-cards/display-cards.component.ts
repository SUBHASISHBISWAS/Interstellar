import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { catchError, EMPTY } from 'rxjs';
import { CardService } from '../card.service';

@Component({
  selector: 'app-display-cards',
  templateUrl: './display-cards.component.html',
  styleUrls: ['./display-cards.component.css'],
})
export class DisplayCardsComponent implements OnInit {
  pageTitle = 'Cards';

  cardtypes$ = this.cardService.cardTypes$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );
  cards$ = this.cardService.cardWithCardType$.pipe(
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

  onSelected(categoryId: string): void {
    console.log('Not yet implemented');
  }
}
