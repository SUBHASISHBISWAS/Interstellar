import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChildren,
} from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControlName,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {
  BehaviorSubject,
  catchError,
  debounceTime,
  EMPTY,
  fromEvent,
  merge,
  Observable,
  Subscription,
} from 'rxjs';
import { GenericValidator } from 'src/app/shared/generic-validator';
import { CardService } from '../card.service';
import { luhnValidator } from '../Helpers/luhn.validators';
import { Card } from '../Models/Card';

@Component({
  selector: 'app-create-card',
  templateUrl: './create-card.component.html',
  styleUrls: ['./create-card.component.css'],
})
export class CreateCardComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements!: ElementRef[];

  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;
  private cardTypeSelectedSubject = new BehaviorSubject<number>(0);
  private sub!: Subscription;

  pageTitle = 'Card Edit';
  displayMessage: { [key: string]: string } = {};
  cardForm!: FormGroup;
  cardFormModel!: Card;
  errorMessage = '';
  cardTypeSelectedAction$ = this.cardTypeSelectedSubject.asObservable();

  cardTypes$ = this.cardService.cardTypes$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  constructor(
    private fb: FormBuilder,
    private cardService: CardService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.validationMessages = {
      cardNumber: {
        required: 'Card Number is required.',
        minlength: 'Card Number must be at least 12 characters.',
        maxlength: 'Card Number cannot exceed 12 characters.',
      },
      cardName: {
        required: 'Card Name is required.',
      },
      starRating: {
        range: 'Rate the product between 1 (lowest) and 5 (highest).',
      },
    };
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void {
    this.cardForm = this.fb.group({
      cardName: [null, [Validators.required, Validators.minLength(3)]],
      cardNumber: [
        null,
        [Validators.required, Validators.minLength(2), Validators.maxLength(2)],
      ],
      cardTypeId: [null],
    });
    this.sub = this.activatedRoute.paramMap.subscribe((params) => {
      const cardId = +params.get('cardId')!;
      this.getCard(cardId);
    });
  }

  getCard(cardId: number): void {
    this.cardService.getCard(cardId).subscribe({
      next: (card: Card) => this.displayCard(card),
      error: (err) => (this.errorMessage = err),
    });
  }

  displayCard(card: Card): void {
    if (this.cardForm) {
      this.cardForm.reset();
    }
    this.cardFormModel = card;
    console.log(this.cardFormModel);
    if (this.cardFormModel.cardId === 0) {
      this.pageTitle = 'Add Card';
    } else {
      this.pageTitle = `Edit Card: ${this.cardFormModel.cardName}`;
    }
  }

  ngAfterViewInit(): void {
    // Watch for the blur event from any input element on the form.
    // This is required because the valueChanges does not provide notification on blur
    console.log(this.formInputElements);
    const controlBlurs: Observable<any>[] = this.formInputElements.map(
      (formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur')
    );

    // Merge the blur event observable with the valueChanges observable
    // so we only need to subscribe once.
    merge(this.cardForm.valueChanges, ...controlBlurs)
      .pipe(debounceTime(800))
      .subscribe((value) => {
        this.displayMessage = this.genericValidator.processMessages(
          this.cardForm
        );
      });
  }

  onSelected(cardTypeId: string): void {
    console.log(+cardTypeId);
    this.cardTypeSelectedSubject.next(+cardTypeId);
    this.cardForm.patchValue({ cardTypeId: +cardTypeId });
  }

  saveCard() {
    if (this.cardForm.valid) {
      if (this.cardForm.dirty) {
        const card = { ...this.cardFormModel, ...this.cardForm.value };

        if (card.cardId === 0) {
          console.log('IT Saved: ' + JSON.stringify(card!));
        }
      } else {
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
    console.log(this.cardForm);
    console.log('Saved: ' + JSON.stringify(this.cardForm.value));
  }
  onSaveComplete(): void {
    this.cardForm.reset();
    console.log('onSaveComplete');
  }
}
