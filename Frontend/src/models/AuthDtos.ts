export interface LoginDTO {
  userName: string;
  password: string;
}

export interface RegistrationRequestDTO {
  userName: string;
  email: string;
  password: string;
  name:string;
  role:string
}

export interface ResetPasswordDTO {
  userId: string;
  currentPassword:string;
  newPassword: string;
  confirmPassword:string;
}

