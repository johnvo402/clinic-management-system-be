export interface RequestError {
  type?: string;
  invalidParams?: {
    propertyName: string;
    reasons: { message: string }[];
  }[];
  ErrorDetail?: string;
}

export const SUCCESS = "SUCCESS";
