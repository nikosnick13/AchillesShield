export interface RegisterRequest {
    username: string;
    email: string;
    password: string;
    roleId: number;
}

export interface LoginRequest {
    username: string;
    password: string;
}

export interface AuthResponse {
    token: string;
    userId: number;
    username: string;
    role: string;
}