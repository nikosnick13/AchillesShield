import {
    createContext,
    useContext,
    useState,
    type ReactNode,
} from "react";

import { login as loginService } from "../services/authService";
import type { LoginRequest, AuthResponse } from "../types/auth";

interface AuthContextType {
    user: AuthResponse | null;
    login: (request: LoginRequest) => Promise<void>;
    logout: () => void;
    isAuthenticated: boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
    const [user, setUser] = useState<AuthResponse | null>(() => {
        const storedUser = localStorage.getItem("user");

        return storedUser ? JSON.parse(storedUser) : null;
    });

    const login = async (request: LoginRequest) => {
        const response = await loginService(request);

        localStorage.setItem("token", response.token);
        localStorage.setItem("user", JSON.stringify(response));

        setUser(response);
    };

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");

        setUser(null);
    };

    return (
        <AuthContext.Provider
            value={{
                user,
                login,
                logout,
                isAuthenticated: user !== null,
            }}
        >
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);

    if (!context) {
        throw new Error("useAuth must be used inside AuthProvider");
    }

    return context;
};