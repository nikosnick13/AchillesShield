import { type FormEvent, useState } from "react";
import { login } from "../services/authService";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleSubmit = async (event: FormEvent) => {
        event.preventDefault();

        try {
            setError("");

            const result = await login({
                username,
                password,
            });

            localStorage.setItem("token", result.token);
            localStorage.setItem(
                "user",
                JSON.stringify(result)
            );

            console.log("Login successful:", result);

        } catch (error) {
            console.error(error);
            setError("Invalid username or password.");
        }
    };

    return (
        <div>
            <h1>AchillesShield</h1>

            <h2>Login</h2>

            <form onSubmit={handleSubmit}>

                <div>
                    <label>Username</label>

                    <input
                        type="text"
                        value={username}
                        onChange={(e) =>
                            setUsername(e.target.value)
                        }
                    />
                </div>

                <div>
                    <label>Password</label>

                    <input
                        type="password"
                        value={password}
                        onChange={(e) =>
                            setPassword(e.target.value)
                        }
                    />
                </div>

                <button type="submit">
                    Login
                </button>

            </form>

            {error && <p>{error}</p>}
        </div>
    );
}

export default Login;