/*
const digitMask = (numDigits: number) => Array(numDigits).fill(/\d/);

export const getValidationConfigFromCardNo = (
  rawValue: string
): CardValidation =>
  cards.find((card) => {
    const patterns = card.patterns.map(
      (pattern) => new RegExp(`^${pattern}`, 'g')
    );
    const matchResult = patterns
      .map((pattern) => rawValue.match(pattern))
      .filter((result) => result);

    return !!matchResult.length;
  }) || null;

const defaultFormat = /(\d{1,4})/g;

export interface CardValidation {
  type: CardBrandEnum;
  patterns: number[];
  mask: any;
  format: RegExp;
  length: number[];
  cvvLength: number[];
  luhn: boolean;
}

export enum CardBrandEnum {
  VISA = 'VISA',
  MASTERCARD = 'MASTERCARD',
  AMERICANEXPRESS = 'AMERICANEXPRESS',
  DISCOVER = 'DISCOVER',
  DINERSCLUB = 'DINERSCLUB',
  JCB = 'JCB',
  MAESTRO = 'MAESTRO',
  UNIONPAY = 'UNIONPAY',
  DANKORT = 'DANKORT',
  FORBRUGSFORENINGEN = 'FORBRUGSFORENINGEN',
}
*/
