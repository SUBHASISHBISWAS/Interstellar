import { DatePipe } from '@angular/common';
import {
  AfterViewInit,
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
  ViewChildren,
} from '@angular/core';
import {
  FormBuilder,
  FormControlName,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsDatepickerDirective } from 'ngx-bootstrap/datepicker';
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
import { Card } from '../Models/Card';

declare var $: any;
@Component({
  selector: 'app-create-card',
  templateUrl: './create-card.component.html',
  styleUrls: ['./create-card.component.css'],
  providers: [DatePipe],
})
export class CreateCardComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements!: ElementRef[];
  @ViewChild(BsDatepickerDirective, { static: false })
  datepicker?: BsDatepickerDirective;

  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;
  private cardTypeSelectedSubject = new BehaviorSubject<number>(0);
  private sub!: Subscription;
  private dateFormat = 'dd-MM-yyyy';

  bsInlineValue = new Date();

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
    private router: Router,
    private datePipe: DatePipe
  ) {
    this.validationMessages = this.getValidationMessage();
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  //#region Life Cycle method

  ngOnInit(): void {
    this.InitilizeControls();
    this.sub = this.activatedRoute.paramMap.subscribe((params) => {
      const cardId = params.get('cardId')!;
      this.getCard(cardId);
    });
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

  //#endregion

  //#region Public method

  onCardTypeSelected(cardTypeId: string): void {
    this.cardTypeSelectedSubject.next(+cardTypeId);
    this.cardForm.patchValue({ cardTypeId: +cardTypeId });
  }

  saveCard() {
    if (this.cardForm.valid) {
      if (this.cardForm.dirty) {
        this.cardForm.patchValue({
          cardStatementDate: this.datePipe.transform(
            this.cardForm.get('cardStatementDate')?.value,
            this.dateFormat
          ),
          cardNextStatementDate: this.datePipe.transform(
            this.cardForm.get('cardNextStatementDate')?.value,
            this.dateFormat
          ),
          cardExpiryDate: this.datePipe.transform(
            this.cardForm.get('cardExpiryDate')?.value,
            this.dateFormat
          ),
          cardDueDate: this.datePipe.transform(
            this.cardForm.get('cardDueDate')?.value,
            this.dateFormat
          ),
        });

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
  @HostListener('window:scroll')
  onScrollEvent() {
    this.datepicker?.hide();
  }

  formatNumber(event: any) {
    let value = event.target.value || '';
    value = value.replace(/[^0-9 ]/, '');
    event.target.value = value;
  }

  //#endregion

  //#region private method

  private convertDateToFromat() {}
  private getCard(cardId: string): void {
    this.cardService.getCard(cardId).subscribe({
      next: (card: Card) => this.displayCard(card),
      error: (err) => (this.errorMessage = err),
    });
  }

  private displayCard(card: Card): void {
    if (this.cardForm) {
      this.cardForm.reset();
    }
    this.cardFormModel = card;
    console.log(this.cardFormModel);
    if (this.cardFormModel.cardId === '') {
      this.pageTitle = 'Add Card';
    } else {
      this.pageTitle = `Edit Card: ${this.cardFormModel.cardName}`;
    }
    //Update the Card From with Data from Server
    this.cardForm.patchValue({
      cardName: this.cardFormModel.cardName,
      cardNumber: this.cardFormModel.cardNumber,
      cardDescription: this.cardFormModel.cardDescription,
      cardType: this.cardFormModel.cardTypeId,
      cardExpiryDate: this.datePipe.transform(
        this.cardFormModel.cardExpiryDate,
        this.dateFormat
      ),
      cardDueDate: this.datePipe.transform(
        this.cardFormModel.cardDueDate,
        this.dateFormat
      ),
      cardStatementDate: this.datePipe.transform(
        this.cardFormModel.cardStatementDate,
        this.dateFormat
      ),
      cardNextStatementDate: this.datePipe.transform(
        this.cardFormModel.cardNextStatementDate,
        this.dateFormat
      ),
      gracePeriod: this.cardFormModel.gracePeriod,
    });
  }

  private onSaveComplete(): void {
    this.cardForm.reset();
    this.router.navigate(['/']);
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
          Validators.pattern('^[ 0-9]*$'),
          Validators.required,
          Validators.minLength(19),
          //Validators.maxLength(15),
        ],
      ],
      cardType: [null, Validators.required],
      cardTypeId: [null, Validators.required],
      cardExpiryDate: [new Date(), Validators.required],
      cardDueDate: [new Date(), Validators.required],
      cardStatementDate: [new Date(), Validators.required],
      cardNextStatementDate: [new Date(), Validators.required],
      gracePeriod: [null, Validators.required],
    });
  }

  private getValidationMessage(): { [key: string]: { [key: string]: string } } {
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
  //#endregion
}
