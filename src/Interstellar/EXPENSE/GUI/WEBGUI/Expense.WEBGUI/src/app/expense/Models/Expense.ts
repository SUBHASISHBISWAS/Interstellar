export interface Expense {
  id: string;
  expenseAmount: number;
  expenseDescription?: string;
  expenseDate?: Date;
  expenseCardId: string;
  expenseCard?: string;
}
