export interface APIResponse<T=any> {
  Result: T;
  IsSuccess: boolean;
  ErrorMessages: string[];
  StatusCode: number;
}

export interface APIRequest {
Url: string;
Method: 'GET' | 'POST' | 'PUT' | 'DELETE';
Data?: any;
Token?: string;
}