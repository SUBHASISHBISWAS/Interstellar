export interface Card {
  id: string;
  cardId: string;
  cardName: string;
  cardTypeId: string;
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
