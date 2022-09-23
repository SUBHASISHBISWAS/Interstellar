import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validator,
  ValidatorFn,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css'],
})
export class RegisterUserComponent implements OnInit {
  userRegistrationForm!: FormGroup;
  constructor(private fb: FormBuilder) {}

  emailMatcher(c: AbstractControl): { [key: string]: boolean } | null {
    const emailControl = c.get('email');
    const emailConfimControl = c.get('confirmEmail');
    if (emailControl?.pristine || emailConfimControl?.pristine) {
      return null;
    }
    if (emailControl?.value === emailConfimControl?.value) {
      return null;
    }
    return { match: true };
  }

  ageRange(min: number, max: number): ValidatorFn {
    return (c: AbstractControl): { [key: string]: boolean } | null => {
      if (
        c.value != null &&
        (isNaN(c.value) || c.value < min || c.value > max)
      ) {
        return { range: true };
      }
      return null;
    };
  }

  ngOnInit(): void {
    this.userRegistrationForm = this.fb.group({
      firstName: [null, [Validators.required, Validators.minLength(3)]],
      emailGroup: this.fb.group(
        {
          email: ['', Validators.required, Validators.email],
          confirmEmail: ['', Validators.required],
        },
        { validator: this.emailMatcher }
      ),
      phone: [null],
      age: [null, this.ageRange(1, 5)],
      notification: 'email',
    });
  }

  save() {
    console.log(this.userRegistrationForm);
    console.log('Saved: ' + JSON.stringify(this.userRegistrationForm.value));
  }
  populateTestData(): void {
    this.userRegistrationForm.patchValue({
      firstName: 'Jack',
      lastName: 'Harkness',
      sendCatalog: false,
    });
  }

  setNotification(notifyVia: string): void {
    const phoneControl = this.userRegistrationForm.get('phone');
    if (notifyVia === 'text') {
      phoneControl?.setValidators(Validators.required);
    } else {
      phoneControl?.clearValidators();
    }
    phoneControl?.updateValueAndValidity();
  }
}
