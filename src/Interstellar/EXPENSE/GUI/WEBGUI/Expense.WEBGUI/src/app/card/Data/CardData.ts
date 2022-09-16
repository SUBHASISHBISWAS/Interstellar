import { InMemoryDbService } from 'angular-in-memory-web-api';
export class CardData implements InMemoryDbService {
  createDb() {
    const cards: Card[] = [
      {
        cardId: 1,
        cardName: 'HDFC',
        cardType: 'VISA',
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date('15-10-1983'),
        cardStatementDate: new Date('15-10-1983'),
        cardDueDate: new Date('15-10-1983'),
        cardNextStatementDate: new Date('15-10-1983'),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
      {
        cardId: 2,
        cardName: 'ICICI',
        cardType: 'VISA',
        cardNumber: '1234-1234-1234-1234',
        cardDescription: 'HDFC BANK CARD',
        cardExpiryDate: new Date('15-10-1983'),
        cardStatementDate: new Date('15-10-1983'),
        cardDueDate: new Date('15-10-1983'),
        cardNextStatementDate: new Date('15-10-1983'),
        gracePeriod: 50,
        cardCurrentMonthExpenditure: 100,
        cardNextMonthExpenditure: 1000,
        cardTotalExpenditure: 10000,
      },
    ];

    return cards;
  }
}
