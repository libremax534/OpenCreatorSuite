export interface User {
  id: number;
  username: string;
  email?: string;
  createdAt: Date;
}

export interface AuthRequest {
  username: string;
  password: string;
}

export interface AuthResponse {
  success: boolean;
  token?: string;
  user?: User;
  message?: string;
}
