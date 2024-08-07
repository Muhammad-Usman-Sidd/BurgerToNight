export interface LoginDTO {
  UserName: string;
  Password: string;
}

export interface RegistrationRequestDTO {
  UserName: string;
  Email?: string;
  PhoneNumber:string
  Password: string;
  Address?:string
  Role?:string;
  SecretKey:string
}

export interface ResetPasswordDTO {
  UserId: string;
  CurrentPassword: string;
  NewPassword: string;
  ConfirmPassword: string;
}

export interface LoginResponseDTO {
  User :{
    Id:string;
  };
  Role :string;
  Token :string;
}

