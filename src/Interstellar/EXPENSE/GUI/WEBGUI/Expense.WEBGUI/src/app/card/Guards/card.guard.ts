import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { CreateCardComponent } from '../create-card/create-card.component';

@Injectable({
  providedIn: 'root',
})
export class CardGuard implements CanDeactivate<CreateCardComponent> {
  canDeactivate(
    component: CreateCardComponent
  ): Observable<boolean> | Promise<boolean> | boolean {
    if (component.cardForm.dirty) {
      const productName =
        component.cardForm.get('cardName')!.value || 'New Card';
      return confirm(`Navigate away and lose all changes to ${productName}?`);
    }
    return true;
  }
}
