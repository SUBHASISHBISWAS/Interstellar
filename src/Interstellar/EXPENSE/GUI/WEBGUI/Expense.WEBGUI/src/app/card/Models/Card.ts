export interface Card {
  cardId: number;
  cardName: string;
  cardTypeId: number;
  cardType?: string;
  cardNumber: string;
  cardDescription?: string;
  cardExpiryDate?: Date;
  cardStatementDate?: Date;
  cardDueDate?: Date;
  cardNextStatementDate?: Date;
  gracePeriod: number;
  cardCurrentMonthExpenditure?: number;
  cardNextMonthExpenditure?: number;
  cardTotalExpenditure?: number;
}
