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
declare var $: any;
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
    this.validationMessages = this.getValidationMessage();
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void {
    this.InitilizeControls();
    this.sub = this.activatedRoute.paramMap.subscribe((params) => {
      const cardId = +params.get('cardId')!;
      this.getCard(cardId);
    });
  }

  private InitilizeControls() {
    this.cardForm = this.fb.group({
      cardName: [
        null,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      cardDescription: [
        null,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      cardNumber: [
        null,
        [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(12),
        ],
      ],
      cardTypeId: [null, Validators.required],
      cardExpiryDate: [null, Validators.required],
      cardDueDate: [null, Validators.required],
      cardStatementDate: [null, Validators.required],
      cardNextStatementDate: [null, Validators.required],
      gracePeriod: [null, Validators.required],
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

  onCardTypeSelected(cardTypeId: string): void {
    this.cardTypeSelectedSubject.next(+cardTypeId);
    this.cardForm.patchValue({ cardTypeId: +cardTypeId });
  }

  saveCard() {
    if (this.cardForm.valid) {
      if (this.cardForm.dirty) {
        const card = { ...this.cardFormModel, ...this.cardForm.value };

        if (card.cardId === 0) {
          // Create New Card
          this.cardService.createCard(card).subscribe({
            next: () => this.onSaveComplete(),
            error: (err) => (this.errorMessage = err),
          });
        }
      } else {
        //Update The Card
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
    console.log('Saved: ' + JSON.stringify(this.cardForm.value));
  }

  onSaveComplete(): void {
    this.cardForm.reset();
    this.router.navigate(['/']);
  }
  getValidationMessage(): { [key: string]: { [key: string]: string } } {
    return {
      cardNumber: {
        required: 'Card Number is required.',
        minlength: 'Card Number must be at least 12 characters.',
        maxlength: 'Card Number cannot exceed 12 characters.',
      },
      cardName: {
        required: 'Card Name is required.',
        minlength: 'Card Number must be at least 4 characters.',
        maxlength: 'Card Number cannot exceed 15 characters.',
      },
      cardDescription: {
        required: 'Card Description is required.',
        minlength: 'Card Number must be at least 4 characters.',
        maxlength: 'Card Number cannot exceed 15 characters.',
      },
      cardExpiryDate: {
        required: 'Expiry Date is required.',
      },
      cardDueDate: {
        required: 'Due Date is required.',
      },
      cardStatementDate: {
        required: 'Statement Date is required.',
      },
      cardNextStatementDate: {
        required: 'Next Statement Date is required.',
      },
      gracePeriod: {
        required: 'GracePeriod is required.',
      },
    };
  }
}
