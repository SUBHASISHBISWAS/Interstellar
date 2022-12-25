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
import {
  BehaviorSubject,
  catchError,
  debounceTime,
  EMPTY,
  fromEvent,
  merge,
  Observable,
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

  displayMessage: { [key: string]: string } = {};
  cardForm!: FormGroup;
  cardModel!: Card;
  errorMessage = '';
  cardTypeSelectedAction$ = this.cardTypeSelectedSubject.asObservable();

  cardTypes$ = this.cardService.cardTypes$.pipe(
    catchError((err) => {
      this.errorMessage = err;
      return EMPTY;
    })
  );

  constructor(private fb: FormBuilder, private cardService: CardService) {
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
      cardId: [null],
      cardName: [null, [Validators.required, Validators.minLength(3)]],
      cardNumber: [
        null,
        [
          Validators.required,
          Validators.minLength(12),
          Validators.maxLength(12),
        ],
      ],
      cardTypeId: [null],
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

  onSelected(cardTypeId: string): void {
    console.log(+cardTypeId);
    this.cardTypeSelectedSubject.next(+cardTypeId);
    this.cardForm.patchValue({ cardTypeId: +cardTypeId });
  }

  save() {
    if (this.cardForm.valid) {
      if (this.cardForm.dirty) {
        const card = { ...this.cardModel };
      }
    }
    console.log(this.cardForm);
    console.log('Saved: ' + JSON.stringify(this.cardForm.value));
  }
  populateTestData(): void {
    this.cardForm.patchValue({
      firstName: 'Jack',
      lastName: 'Harkness',
      sendCatalog: false,
    });
  }
}
