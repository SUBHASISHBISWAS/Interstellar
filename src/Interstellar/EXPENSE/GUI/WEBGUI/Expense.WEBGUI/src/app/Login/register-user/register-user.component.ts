import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css'],
})
export class RegisterUserComponent implements OnInit {
  userRegistrationForm!: FormGroup;
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.userRegistrationForm = this.fb.group({
      firstName: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.required, Validators.email]],
      phone: [null],
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
