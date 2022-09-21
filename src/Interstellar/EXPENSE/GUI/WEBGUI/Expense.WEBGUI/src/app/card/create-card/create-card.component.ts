import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CardService } from '../card.service';

@Component({
  selector: 'app-create-card',
  templateUrl: './create-card.component.html',
  styleUrls: ['./create-card.component.css'],
})
export class CreateCardComponent implements OnInit {
  cardForm!: FormGroup;
  constructor(private fb: FormBuilder, private cardService: CardService) {}

  ngOnInit(): void {
    this.cardForm = this.fb.group({
      cardName: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, [Validators.required, Validators.email]],
      phone: [null],
      notification: 'email',
    });
  }
  save() {
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

  setNotification(notifyVia: string): void {
    const phoneControl = this.cardForm.get('phone');
    if (notifyVia === 'text') {
      phoneControl?.setValidators(Validators.required);
    } else {
      phoneControl?.clearValidators();
    }
    phoneControl?.updateValueAndValidity();
  }
}
