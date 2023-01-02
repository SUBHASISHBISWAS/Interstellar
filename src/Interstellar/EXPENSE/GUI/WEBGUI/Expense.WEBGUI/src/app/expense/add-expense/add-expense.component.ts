import { DatePipe } from '@angular/common';
import {
  Component,
  ElementRef,
  HostListener,
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
import { Guid } from 'guid-typescript';
import { BsDatepickerDirective } from 'ngx-bootstrap/datepicker';
import {
  BehaviorSubject,
  debounceTime,
  fromEvent,
  merge,
  Observable,
  Subscription,
} from 'rxjs';
import { GenericValidator } from 'src/app/shared/generic-validator';
import { ExpenseService } from '../expense.service';
import { Expense } from '../Models/Expense';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css'],
})
export class AddExpenseComponent {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements!: ElementRef[];
  @ViewChild(BsDatepickerDirective, { static: false })
  datepicker?: BsDatepickerDirective;

  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;
  private cardSelectedSubject = new BehaviorSubject<number>(0);
  private sub!: Subscription;
  private dateFormat = 'dd-MM-yyyy';

  bsInlineValue = new Date();

  pageTitle = 'Edit Expense';
  displayMessage: { [key: string]: string } = {};
  expenseForm!: FormGroup;
  expenseFormModel!: Expense;
  errorMessage = '';

  cards$ = this.expenseService.cards$;

  ngOnInit(): void {
    this.InitilizeControls();
    this.sub = this.activatedRoute.paramMap.subscribe((params) => {
      const id = params.get('id')!;
      this.getExpense(id);
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
    merge(this.expenseForm.valueChanges, ...controlBlurs)
      .pipe(debounceTime(800))
      .subscribe((value) => {
        this.displayMessage = this.genericValidator.processMessages(
          this.expenseForm
        );
      });
  }

  constructor(
    private fb: FormBuilder,
    private expenseService: ExpenseService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe
  ) {
    this.validationMessages = this.getValidationMessage();
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  onCardSelected(cardId: string): void {
    this.cardSelectedSubject.next(+cardId);
    this.expenseForm.patchValue({ expenseCardId: +cardId });
  }

  saveExpense() {
    if (this.expenseForm.valid) {
      if (this.expenseForm.dirty) {
        this.expenseForm.patchValue({
          cardStatementDate: this.datePipe.transform(
            this.expenseForm.get('expenseDate')?.value,
            this.dateFormat
          ),
        });
        console.log(Guid.create());
        const cardType = {
          ...this.expenseFormModel,
          ...this.expenseForm.value,
        };

        if (cardType.id === 0) {
          // Add new Expense
          this.expenseService.addExpense(cardType).subscribe({
            next: () => this.onSaveComplete(),
            error: (err: string) => (this.errorMessage = err),
          });
        }
      } else {
        //Update Expense
        this.onSaveComplete();
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
    console.log('Saved: ' + JSON.stringify(this.expenseForm.value));
  }
  @HostListener('window:scroll')
  onScrollEvent() {
    this.datepicker?.hide();
  }
  private getExpense(id: string): void {
    this.expenseService.getExpense(id).subscribe({
      next: (expense: Expense) => this.displayExpense(expense),
      error: (err: string) => (this.errorMessage = err),
    });
  }

  private displayExpense(expense: Expense): void {
    if (this.expenseForm) {
      this.expenseForm.reset();
    }
    this.expenseFormModel = expense;
    console.log(this.expenseFormModel);
    if (this.expenseFormModel.id === '') {
      this.pageTitle = 'Add Expense';
    } else {
      this.pageTitle = `Edit Expense: ${this.expenseFormModel.expenseDescription}`;
    }
    //Update the Card From with Data from Server
    console.log('SUBHASISH' + this.expenseFormModel.expenseDate);
    this.expenseForm.patchValue({
      expenseAmount: this.expenseFormModel.expenseAmount,
      expenseDescription: this.expenseFormModel.expenseDescription,
      expenseCardId: this.expenseFormModel.expenseCardId,
      expenseDate: this.datePipe.transform(
        this.expenseFormModel.expenseDate,
        this.dateFormat
      ),
    });
    console.log(
      'SUBHASISH' +
        this.datePipe.transform(
          this.expenseFormModel.expenseDate,
          this.dateFormat
        )
    );
  }

  private onSaveComplete(): void {
    this.expenseForm.reset();
    this.router.navigate(['/expenses']);
  }

  private InitilizeControls() {
    this.expenseForm = this.fb.group({
      expenseAmount: [null, [Validators.required]],
      expenseDescription: [
        null,
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(15),
        ],
      ],
      expenseCardId: [],
      expenseDate: [new Date(), Validators.required],
    });
  }

  private getValidationMessage(): { [key: string]: { [key: string]: string } } {
    return {
      expenseAmount: {
        required: 'Expense Amount is required.',
      },
      expenseDescription: {
        required: 'Description is required.',
        minlength: 'Description must be at least 4 characters.',
        maxlength: 'Description cannot exceed 15 characters.',
      },
      expenseCardId: {
        required: 'Expense Card is required.',
      },
      expenseDate: {
        required: 'Expense Date is required.',
      },
    };
  }
}
