import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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
      cardName: null,
      cardNumber: null,
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
}
