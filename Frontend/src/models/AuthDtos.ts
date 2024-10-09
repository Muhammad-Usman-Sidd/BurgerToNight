export interface LoginDTO {
  UserName: string;
  Password: string;
}

export interface RegistrationRequestDTO {
  UserName: string;
  Email?: string;
  PhoneNumber: string;
  Password: string;
  Address?: string;
  Role?: string;
  SecretKey: string;
}

export interface ResetPasswordDTO {
  UserId: string;
  CurrentPassword: string;
  NewPassword: string;
  ConfirmPassword: string;
}

export interface LoginResponseDTO {
  User: UserDTO;
  Token: string;
  Role: string;
}

export interface ContactDTO {
  UserId: string;
  Name: string;
  Email?: string;
  Message: string;
}

export interface UserDTO {
  Id: string;
  TotalOrders: number;
  TotalAmountSpent: number;
  UserName: string;
  Name: string;
  PhoneNumber: string;
  Address: string;
}
