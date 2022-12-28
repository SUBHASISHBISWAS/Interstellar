//https://stackoverflow.com/questions/41458040/how-to-in-memory-web-api-for-two-different-jsons
//https:stackoverflow.com/questions/40146811/multiple-collections-in-angular-in-memory-web-api

import { InMemoryDbService } from 'angular-in-memory-web-api';
import { CardType } from '../card-types/Models/CardTypes';
import { Card } from '../card/Models/Card';
export class CardInMemoryMockData implements InMemoryDbService {
  createDb() {
    const cards: Card[] = [
      {
        id: 1,
        cardId: 1,
        cardName: 'HDFC',
        cardTypeId: 1,
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date(1983, 10, 15),
        cardStatementDate: new Date(1983, 10, 15),
        cardDueDate: new Date(1983, 10, 15),
        cardNextStatementDate: new Date(1983, 10, 15),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
      {
        id: 2,
        cardId: 2,
        cardName: 'ICICI',
        cardTypeId: 2,
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date(1983, 10, 15),
        cardStatementDate: new Date(1983, 10, 15),
        cardDueDate: new Date(1983, 10, 15),
        cardNextStatementDate: new Date(1983, 10, 15),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
      {
        id: 3,
        cardId: 3,
        cardName: 'AMEX',
        cardTypeId: 3,
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'AMEX BANK CARD',
        cardExpiryDate: new Date(1983, 10, 15),
        cardStatementDate: new Date(1983, 10, 15),
        cardDueDate: new Date(1983, 10, 15),
        cardNextStatementDate: new Date(1983, 10, 15),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
    ];

    const cardtypes: CardType[] = [
      {
        id: 1,
        name: 'VISA',
        description: 'My VISA',
        createdDate: new Date(1983, 10, 15),
      },
      {
        id: 2,
        name: 'MASTER',
        description: 'My MASTER',
        createdDate: new Date(1983, 10, 15),
      },
      {
        id: 3,
        name: 'AMEX',
        description: 'My AMEX',
        createdDate: new Date(1983, 10, 15),
      },
    ];

    return { cards, cardtypes };
  }

  /*
  genId(cards: Card[]): number {
    return cards.length > 0
      ? Math.max(...cards.map((hero) => hero.cardId)) + 1
      : 11;
  }
  */
  genId<T extends Card | CardType>(myTable: T[]): number {
    return myTable.length > 0 ? Math.max(...myTable.map((t) => t.id)) + 1 : 11;
  }
}
