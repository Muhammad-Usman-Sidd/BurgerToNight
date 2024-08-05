export interface LoginDTO {
  userName: string;
  password: string;
}

export interface RegistrationRequestDTO {
  userName: string;
  email: string;
  password: string;
  role:string;
  secretKey:string
}

export interface ResetPasswordDTO {
  userId: string;
  currentPassword: string;
  newPassword: string;
  confirmPassword: string;
}

export interface LoginResponseDTO {
  User :{
    Id:string;
  };
  Role :string;
  Token :string;
}

