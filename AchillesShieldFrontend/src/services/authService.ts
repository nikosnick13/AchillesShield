import api from "./api";
import type {
    LoginRequest,
    RegisterRequest,
    AuthResponse,
} from "../types/auth";

export const register = async (
    request: RegisterRequest
): Promise<AuthResponse> => {
    const response = await api.post<AuthResponse>(
        "/auth/register",
        request
    );

    return response.data;
};

export const login = async (
    request: LoginRequest
): Promise<AuthResponse> => {
    const response = await api.post<AuthResponse>(
        "/auth/login",
        request
    );

    return response.data;
};