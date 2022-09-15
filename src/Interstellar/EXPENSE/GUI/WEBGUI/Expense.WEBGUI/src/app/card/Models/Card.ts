interface Card {
  cardId: Int;
  cardName: string;
  cardType: string;
  cardNumber: string;
  cardDescription: string;
  cardExpieryDate: Date;
  cardStatementDate: Date;
  cardDueDate: Date;
  cardNextStatementDate: Date;
  gracePeriod: Int;
  cardCurrentMonthExpenditure: Double;
  cardNextMonthExpenditure: Double;
  cardTotalExpenditure: Double;
}
