import { Directive, HostListener, ElementRef } from '@angular/core';
//https://www.appsloveworld.com/angular/100/30/add-space-after-every-4th-digit-in-input

@Directive({
  selector: '[credit-card]',
})
export class CreditCardDirective {
  @HostListener('input', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    const input = event.target as HTMLInputElement;

    let trimmed = input.value.replace(/\s+/g, '');
    if (trimmed.length > 16) {
      trimmed = trimmed.substr(0, 16);
    }

    let numbers = [];
    for (let i = 0; i < trimmed.length; i += 4) {
      numbers.push(trimmed.substr(i, 4));
    }

    input.value = numbers.join(' ');
  }
}
