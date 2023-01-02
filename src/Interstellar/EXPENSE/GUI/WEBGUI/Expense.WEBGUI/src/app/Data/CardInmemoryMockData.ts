//https://stackoverflow.com/questions/41458040/how-to-in-memory-web-api-for-two-different-jsons
//https:stackoverflow.com/questions/40146811/multiple-collections-in-angular-in-memory-web-api
//https://stackoverflow.com/questions/439630/create-a-date-with-a-set-timezone-without-using-a-string-representation
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Guid } from 'guid-typescript';
import { CardType } from '../card-types/Models/CardTypes';
import { Card } from '../card/Models/Card';
import { Expense } from '../expense/Models/Expense';
export class CardInMemoryMockData implements InMemoryDbService {
  createDb() {
    const cards: Card[] = [
      {
        id: Guid.parse('30abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardId: Guid.parse('30abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardName: 'HDFC',
        cardTypeId: Guid.parse(
          '28abe6fb-7ee8-05b7-a89e-f71c878729fd'
        ).toString(),
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date(Date.UTC(1983, 9, 15)),
        cardStatementDate: new Date(Date.UTC(1983, 9, 15)),
        cardDueDate: new Date(Date.UTC(1983, 9, 15)),
        cardNextStatementDate: new Date(Date.UTC(1983, 9, 15)),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
      {
        id: Guid.parse('31abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardId: Guid.parse('31abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardName: 'ICICI',
        cardTypeId: Guid.parse(
          '28abe6fb-7ee8-05b7-a89e-f71c878729ff'
        ).toString(),
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date(Date.UTC(1983, 9, 15)),
        cardStatementDate: new Date(Date.UTC(1983, 9, 15)),
        cardDueDate: new Date(Date.UTC(1983, 9, 15)),
        cardNextStatementDate: new Date(Date.UTC(1983, 9, 15)),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
      {
        id: Guid.parse('32abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardId: Guid.parse('32abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        cardName: 'AMEX',
        cardTypeId: Guid.parse(
          '28abe6fb-7ee8-05b7-a89e-f71c878729fg'
        ).toString(),
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'AMEX BANK CARD',
        cardExpiryDate: new Date(Date.UTC(1983, 9, 15)),
        cardStatementDate: new Date(Date.UTC(1983, 9, 15)),
        cardDueDate: new Date(Date.UTC(1983, 9, 15)),
        cardNextStatementDate: new Date(Date.UTC(1983, 9, 15)),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
    ];

    const cardtypes: CardType[] = [
      {
        id: Guid.parse('28abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        name: 'VISA',
        description: 'My VISA',
        createdDate: new Date(Date.UTC(1983, 9, 15)),
      },
      {
        id: Guid.parse('28abe6fb-7ee8-05b7-a89e-f71c878729ff').toString(),
        name: 'MASTER',
        description: 'My MASTER',
        createdDate: new Date(Date.UTC(1983, 9, 15)),
      },
      {
        id: Guid.parse('28abe6fb-7ee8-05b7-a89e-f71c878729fg').toString(),
        name: 'AMEX',
        description: 'My AMEX',
        createdDate: new Date(Date.UTC(1983, 9, 15)),
      },
    ];

    const expenses: Expense[] = [
      {
        id: Guid.parse('25abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        expenseAmount: 1000,
        expenseDescription: 'FreshCo',
        expenseCardId: Guid.parse(
          '30abe6fb-7ee8-05b7-a89e-f71c878729fd'
        ).toString(),
        expenseDate: new Date(Date.UTC(2023, 9, 15)),
      },
      {
        id: Guid.parse('26abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        expenseAmount: 2000,
        expenseDescription: 'ShopON',
        expenseCardId: Guid.parse(
          '31abe6fb-7ee8-05b7-a89e-f71c878729fd'
        ).toString(),
        expenseDate: new Date(Date.UTC(2024, 9, 15)),
      },
      {
        id: Guid.parse('26abe6fb-7ee8-05b7-a89e-f71c878729fd').toString(),
        expenseAmount: 3000,
        expenseDescription: 'HyperBazar',
        expenseCardId: Guid.parse(
          '32abe6fb-7ee8-05b7-a89e-f71c878729fd'
        ).toString(),
        expenseDate: new Date(Date.UTC(2025, 9, 15)),
      },
    ];

    return { cards, cardtypes, expenses };
  }

  /*
  genId(cards: Card[]): number {
    return cards.length > 0
      ? Math.max(...cards.map((hero) => hero.cardId)) + 1
      : 11;
  }
  */
  genId<T extends Card | CardType | Expense>(myTable: T[]): string {
    return ''; //myTable.length > 0 ? Math.max(...myTable.map((t) => t.id)) + 1 : 11;
  }
}
