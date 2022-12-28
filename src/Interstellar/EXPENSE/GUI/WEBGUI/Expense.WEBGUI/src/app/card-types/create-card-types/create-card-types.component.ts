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
  debounceTime,
  fromEvent,
  merge,
  Observable,
  Subscription,
} from 'rxjs';
import { CardType } from 'src/app/card-types/Models/CardTypes';
import { GenericValidator } from 'src/app/shared/generic-validator';
import { CardTypeService } from '../card-type.service';

@Component({
  selector: 'app-create-card-types',
  templateUrl: './create-card-types.component.html',
  styleUrls: ['./create-card-types.component.css'],
})
export class CreateCardTypesComponent implements OnInit, AfterViewInit {
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

  pageTitle = 'CardType Edit';
  displayMessage: { [key: string]: string } = {};
  cardTypeForm!: FormGroup;
  cardTypeFormModel!: CardType;
  errorMessage = '';
  cardTypeSelectedAction$ = this.cardTypeSelectedSubject.asObservable();

  ngOnInit(): void {
    this.InitilizeControls();
    this.sub = this.activatedRoute.paramMap.subscribe((params) => {
      const id = +params.get('id')!;
      this.getCardType(id);
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
    merge(this.cardTypeForm.valueChanges, ...controlBlurs)
      .pipe(debounceTime(800))
      .subscribe((value) => {
        this.displayMessage = this.genericValidator.processMessages(
          this.cardTypeForm
        );
      });
  }

  constructor(
    private fb: FormBuilder,
    private cardTypeService: CardTypeService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe
  ) {
    this.validationMessages = this.getValidationMessage();
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  saveCardType() {
    if (this.cardTypeForm.valid) {
      if (this.cardTypeForm.dirty) {
        this.cardTypeForm.patchValue({
          cardStatementDate: this.datePipe.transform(
            this.cardTypeForm.get('createdDate')?.value,
            this.dateFormat
          ),
        });

        const cardType = {
          ...this.cardTypeFormModel,
          ...this.cardTypeForm.value,
        };

        if (cardType.id === 0) {
          console.log('hello');
          // Create New Card
          this.cardTypeService.createCardType(cardType).subscribe({
            next: () => this.onSaveComplete(),
            error: (err: string) => (this.errorMessage = err),
          });
        }
      } else {
        //Update The Card
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
    console.log('Saved: ' + JSON.stringify(this.cardTypeForm.value));
  }
  @HostListener('window:scroll')
  onScrollEvent() {
    this.datepicker?.hide();
  }
  private getCardType(id: number): void {
    this.cardTypeService.getCardType(id).subscribe({
      next: (cardType: CardType) => this.displayCardType(cardType),
      error: (err: string) => (this.errorMessage = err),
    });
  }

  private displayCardType(cardType: CardType): void {
    if (this.cardTypeForm) {
      this.cardTypeForm.reset();
    }
    this.cardTypeFormModel = cardType;
    console.log(this.cardTypeFormModel);
    if (this.cardTypeFormModel.id === 0) {
      this.pageTitle = 'Add Card Type';
    } else {
      this.pageTitle = `Edit Card: ${this.cardTypeFormModel.name}`;
    }
    //Update the Card From with Data from Server
    console.log('SUBHASISH' + this.cardTypeFormModel.createdDate);
    this.cardTypeForm.patchValue({
      name: this.cardTypeFormModel.name,
      description: this.cardTypeFormModel.description,
      createdDate: this.datePipe.transform(
        this.cardTypeFormModel.createdDate,
        this.dateFormat
      ),
    });
    console.log(
      'SUBHASISH' +
        this.datePipe.transform(
          this.cardTypeFormModel.createdDate,
          this.dateFormat
        )
    );
  }

  private onSaveComplete(): void {
    this.cardTypeForm.reset();
    this.router.navigate(['/cardtypes']);
  }

  private InitilizeControls() {
    this.cardTypeForm = this.fb.group({
      name: [
        null,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      description: [
        null,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      createdDate: [new Date(), Validators.required],
    });
  }

  private getValidationMessage(): { [key: string]: { [key: string]: string } } {
    return {
      name: {
        required: 'Name is required.',
        minlength: 'Name must be at least 4 characters.',
        maxlength: 'Name cannot exceed 15 characters.',
      },
      description: {
        required: 'Description is required.',
        minlength: 'Description must be at least 4 characters.',
        maxlength: 'Description cannot exceed 15 characters.',
      },
      createdDate: {
        required: 'Created Date is required.',
      },
    };
  }
}
